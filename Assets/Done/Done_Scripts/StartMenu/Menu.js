#pragma strict

function QuitGame () {
    Application.Quit();
}

function StartGame () {
    Application.LoadLevel(1);
}

function BackToMainMenu()
{
    Application.LoadLevel(0);
}

function OpenReadMe()
{
    Application.LoadLevel(2);
}

function GoToQuitConfirmation(){
    Application.LoadLevel(3);
}