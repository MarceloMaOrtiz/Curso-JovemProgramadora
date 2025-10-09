const API = "https://localhost:7133/gtapi/"; // ajuste porta da WebApi

function alerta() {
    return alert("Alerta Gerado!!!");
}

function mascaraData(dataIso) {
    const [ano, mes, dia] = dataIso.split("-");
    return `${dia}/${mes}/${ano}`;
}

function mascaraCpf(cpf) {
    cpf = cpf.replace(/\D/g, "");
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
}

document.getElementById("btnListar").addEventListener("click", async () => {
    const urlApi = API + "alunos"; // "https://localhost:7133/gtapi/alunos"
    const resp = await fetch(urlApi);
    const json = await resp.json();

    const ttabela = document.getElementById("tabela");
    const tbody = ttabela.querySelector("tbody");
    tbody.innerHTML = "";
    try {
        if (json.sucesso) {
            json.objeto.forEach(aluno => {
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
            });
        } else {
            alert("Erro: " + json.mensagem);
        }
    } catch (err) {
        alert('Erro ao listar: ' + err.message);
    }
});