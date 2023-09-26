// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function randomize(url) {
    document.getElementById('card').style.backgroundColor = randomColors();
    document.getElementById('question').innerHTML = getRandomQuestion(url);
}

// random colors - taken from here:
// http://www.paulirish.com/2009/random-hex-color-code-snippets/

function randomColors() {
    return '#' + Math.floor(Math.random() * 16777215).toString(16);
}

async function getVulnerableQuestions(url){
    const response = await fetch(url);
    var data = await response.json();
    console.log(data);
    return data;
}

async function getRandomQuestion(url) {
    const questionsList = await getVulnerableQuestions(url);
    var question = questionsList[Math.floor(Math.random()*questionsList.length)];
    console.log(question);
    displayQuestion(question.question);
}

function displayQuestion(question) {
    const questionHeading = document.getElementById("question");
    questionHeading.innerHTML = question;
}