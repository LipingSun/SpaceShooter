#pragma strict

function QuitGame () {
    Application.Quit();
}

function StartGame () {
    Application.LoadLevel("PlayerCreate");
}

function BackToMainMenu()
{
    Application.LoadLevel("StartMenu");
}

function OpenReadMe()
{
    Application.LoadLevel("ReadMe");
}

function GoToQuitConfirmation(){
    Application.LoadLevel("QuitConfirmation");
}