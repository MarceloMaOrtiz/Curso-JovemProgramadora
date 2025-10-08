const API = "https://localhost:7133/gtapi/"; // ajuste porta da WebApi

document.getElementById('formCadastro').addEventListener('submit', async function (e) {
    e.preventDefault();
    const form = e.target;
    const data = {
        nome: form.nome.value,
        dataNascimento: form.dataNascimento.value,
        cpf: form.cpf.value,
        media: parseFloat(form.media.value)
    };
    try {
        const urlApi = API + "cadastro_aluno";
        const response = await fetch(urlApi, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        const json = await response.json();

        if (json.sucesso) {
            alert('Aluno cadastrado com sucesso!');
            form.reset();
        } else {
            alert('Erro ao cadastrar: ' + json.mensagem);
        }
    } catch (err) {
        alert('Erro de conexão: ' + err.message);
    }
})