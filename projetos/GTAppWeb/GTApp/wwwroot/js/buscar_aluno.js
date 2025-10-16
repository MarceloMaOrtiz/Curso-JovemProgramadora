const API = "https://localhost:7133/gtapi/"; // ajuste porta da WebApi

function mascaraData(dataIso) {
    const [ano, mes, dia] = dataIso.split("-");
    return `${dia}/${mes}/${ano}`;
}

function mascaraCpf(cpf) {
    cpf = cpf.replace(/\D/g, "");
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
}

document.getElementById("formBusca").addEventListener("submit", async function (e) {
    e.preventDefault();

    const form = e.target;
    const urlApi = API + "buscar_aluno?cpf=" + form.cpf.value;

    try {
        const resp = await fetch(urlApi);
        const json = await resp.json();

        const ttabela = document.getElementById("tabela");
        const tbody = ttabela.querySelector("tbody");
        tbody.innerHTML = "";

        if (resp.status == 404) {
            alert("Aluno não encontrado!");
        } else if (resp.status == 400) {
            alert("CPF inválido: " + json.mensagem);
        } else if (resp.status == 200) {
            if (json.sucesso) {
                const aluno = json.objeto;
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
                alert("Erro: " + json.mensagem);
            }
        } else {
            alert("Erro inesperado:" + resp.statusText)
        }
    } catch (err) {
        alert('Erro ao listar: ' + err.message);
    }
});