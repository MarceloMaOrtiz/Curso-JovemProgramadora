const API = "https://localhost:7133/gtapi/"; // ajuste porta da WebApi

function mascaraData(dataIso) {
    const [ano, mes, dia] = dataIso.split("-");
    return `${dia}/${mes}/${ano}`;
}

function mascaraCpf(cpf) {
    cpf = cpf.replace(/\D/g, "");
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
}

document.getElementById('formBusca').addEventListener('submit', async function (e) {
    e.preventDefault();
    const form = e.target;
    try {
        const urlApi = API + "buscar_aluno?cpf=" + form.cpf.value;
        const response = await fetch(urlApi);
        const json = await response.json();
        if (response.status == 200) {
            if (json.sucesso) {
                form.reset();
                if (json.objeto != null) {
                    const ttabela = document.getElementById("tabela");
                    const tbody = ttabela.querySelector("tbody");
                    tbody.innerHTML = "";
                    const aluno = json.objeto; // Corrigido: pegar o aluno do json
                    const tr = document.createElement("tr");
                    tr.innerHTML = `
                        <td>${aluno.id}</td>
                        <td>${aluno.nome}</td>
                        <td>${mascaraData(aluno.dataNascimento.valor)}</td>
                        <td>${mascaraCpf(aluno.cpf.valor)}</td>
                        <td>${aluno.media}</td>
                        <td>${aluno.aprovado ? "Aprovado" : "Reprovado"}</td>
                    `;
                    tbody.appendChild(tr);
                } else {
                    alert(json.mensagem);
                }
            } else {
                alert('Erro ao buscar: ' + json.mensagem);
            }
        } else if (response.status == 400) {
            alert(json.mensagem);
        }
    } catch (err) {
        alert('Erro de conexão: ' + err.message);
    }
})