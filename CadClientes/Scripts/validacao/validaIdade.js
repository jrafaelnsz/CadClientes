function ValidaIdade(dataNascimento) {
    console.log(dataNascimento);
    var partes = dataNascimento.split('-');
    var mydate = new Date(partes[0], partes[1] - 1, partes[2]); 
    const agora = new Date(); 
    const diferenca = Math.abs(agora.getTime() - mydate.getTime()); 
    const idade = Math.ceil((diferenca / (1000 * 60 * 60 * 24) / 365.25)); 
    console.log(idade);
    return (idade >= 18);
}