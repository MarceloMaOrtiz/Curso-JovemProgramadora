const API = "https://localhost:7085/api/alunos"; // ajuste porta da WebApi

function mascaraData(dataIso) {
    const [ano, mes, dia] = dataIso.split("-");
    return `${dia}/${mes}/${ano}`;
}

function mascaraCpf(cpf) {
    cpf = cpf.replace(/\D/g, "");
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
}

document.getElementById("btnCarregar").addEventListener("click", async () => {
    const resp = await fetch(API);
    const json = await resp.json();
    const ul = document.getElementById("lista");
    ul.innerHTML = "";
    json.objeto.forEach(aluno => {
        const li = document.createElement("li");
        li.textContent = `ID: ${aluno.id} | Nome: ${aluno.nome} | Nascimento: ${mascaraData(aluno.dataNascimento.valor)} | CPF: ${mascaraCpf(aluno.cpf.valor)} | Média: ${aluno.media}`;
        ul.appendChild(li);
    });
});