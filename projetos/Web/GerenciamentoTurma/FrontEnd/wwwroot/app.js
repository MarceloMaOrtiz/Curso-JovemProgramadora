const API = "http://localhost:5000/api/alunos"; // ajuste porta da WebApi

document.getElementById("btnCarregar").addEventListener("click", async () => {
    const resp = await fetch(API);
    const json = await resp.json();
    const ul = document.getElementById("lista");
    ul.innerHTML = "";
    json.dados.forEach(a => {
        const li = document.createElement("li");
        li.textContent = a.nome;
        ul.appendChild(li);
    });
});