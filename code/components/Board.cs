using Sandbox;

public sealed class Board : Component
{
	[Property] public GameObject Timer { get; set; }
	[Property] public GameObject ScoreLeft { get; set; }
	[Property] public GameObject ScoreRight { get; set; }
	[Property] public GameObject Left { get; set; }
	[Property] public GameObject Right { get; set; }
	[Property] public GameObject Top { get; set; }
	[Property] public GameObject Bottom { get; set; }
	[Property] public GameObject PaddleLeft { get; set; }
	[Property] public GameObject PaddleRight { get; set; }
}
