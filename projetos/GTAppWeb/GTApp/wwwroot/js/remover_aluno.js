const API = "https://localhost:7133/gtapi/"; // ajuste porta da WebApi
document.getElementById('formRemover').addEventListener('submit', async function (e) {
    e.preventDefault();
    const form = e.target;
    const data = { cpf: form.cpf.value };

    try {
        const urlApi = API + "remover_aluno";
        const response = await fetch(urlApi, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        const json = await response.json();
        if (response.status == 200) {
            alert("Aluno " + json.objeto.nome + " removido com sucesso.");
            form.reset();
            window.location.href = '/';
        } else if (response.status == 404) {
            alert("Aluno não encontrado");
        } else {
            alert('Erro ao desativar: ' + (json.mensagem || response.statusText));
        }
    } catch (err) {
        alert('Erro de conexão: ' + err.message);
    }
});