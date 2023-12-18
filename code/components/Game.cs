using Sandbox;

public sealed class GameManger : Component
{
	[Property] public GameObject BallPrefab { get; set; }
	[Property] public int ScoreLimit { get; set; } = 3;

	public float GameTime = 0f;
	public int ScoreLeft = 0;
	public int ScoreRight = 0;

	private bool gamePlaying = false;
	private GameObject ball;

	protected override void OnStart()
	{
		GameStart();
	}
	protected override void OnUpdate()
	{
		if (gamePlaying) GameTime += Time.Delta;
		if ( ScoreLeft >= ScoreLimit || ScoreLeft >= ScoreLimit ) GameEnd();
	}
	public void Score(int Team)
	{
		if ( Team == 0 )
		{
			ScoreLeft++;
		}
		else
		{
			ScoreRight++;
		}

		SpawnBall();
	}
	void SpawnBall()
	{
		ball?.Destroy();
		ball = SceneUtility.Instantiate( BallPrefab, Vector3.Zero, BallPrefab.Transform.Rotation );
	}
	void GameStart()
	{
		gamePlaying = true;
		ball = SceneUtility.Instantiate( BallPrefab, Vector3.Zero, BallPrefab.Transform.Rotation );
	}
	void GameEnd()
	{
		ball?.Destroy();
		//End screen
	}
}
