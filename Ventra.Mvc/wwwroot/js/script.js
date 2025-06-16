var deleteButtons = document.querySelectorAll('[data-bs-target="#deleteModal"]');
deleteButtons.forEach(function (button) {
    button.addEventListener('click', function () {
        var Id = button.getAttribute('data-id');
        var Nome = button.getAttribute('data-nome');
        document.getElementById('itemParaDeletar').textContent = Nome;
        document.getElementById('idParaDeletar').value = Id;
    });
});

function ImgError(source) {
    source.src = "/img/static/no_photo.jpg"
    source.onerror = "";
    return true;
}