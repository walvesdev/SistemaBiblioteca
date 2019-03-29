function carregarUrl(meuControle) {
    if (meuControle.options[meuControle.selectedIndex].value) {
        window.location = meuControle.options[meuControle.selectedIndex].value;
    }
}