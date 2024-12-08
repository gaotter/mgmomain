const mainButton = document.getElementById('load-content');

mainButton.addEventListener('click', async () => {
    const mainContent = document.getElementById('main-content');
    const response = await fetch('articles/post1.html');
    const content = await response.text();

    mainContent.innerHTML = content;
});