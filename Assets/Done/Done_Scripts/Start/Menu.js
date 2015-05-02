#pragma strict

function QuitGame () {
    Application.Quit();
}

function StartGame () {
    Application.LoadLevel("PlayerMenu");
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