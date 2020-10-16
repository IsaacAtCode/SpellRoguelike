using UnityEngine;
using UnityEngine.UI;

namespace IAG.Menus
{
	public class MenuChanger : MonoBehaviour
	{
		[SerializeField] GameObject main;
		[SerializeField] GameObject option;
		[SerializeField] GameObject game;

		public MenuState menuState; //Change this to change the menu;

		private void Start()
		{
			OpenMain();
		}

		private void Update()
		{
			switch (menuState)
			{
				case MenuState.Main:
					OpenMain();
					break;
				case MenuState.Option:
					OpenOption();
					break;
				case MenuState.Game:
					OpenGame();
					break;
				default: 
					OpenMain();
					break;
			}
		}

		public void ChangeMenuState(int state)
		{
			menuState = (MenuState)state;
		}

		private void HideAll()
		{
			main.SetActive(false);
			option.SetActive(false);
			game.SetActive(false);
		}

		private void OpenMain()
		{
			HideAll();

			main.SetActive(true);
		}

		private void OpenOption()
		{
			HideAll();

			option.SetActive(true);
		}

		private void OpenGame()
		{
			HideAll();

			game.SetActive(true);
		}
	}

	public enum MenuState
	{
		Main,
		Option,
		Game
	}

}

