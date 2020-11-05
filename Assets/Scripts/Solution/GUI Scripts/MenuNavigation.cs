using UnityEngine;
using System.Collections;

public class MenuNavigation : MonoBehaviour {

	public void MainMenu()
	{
		Application.LoadLevel("menu");
	}

	public void Quit()
	{
		Application.Quit();
	}
	
	public void Play()
	{
		Application.LoadLevel("Solution");
	}

	public void SourceCode()
	{
		Application.OpenURL("https://github.com/vilbeyli/Pacman-Clone/");
	}
}
