using Sandbox;
using System.Linq;

public sealed class Ball : Component, Component.ITriggerListener
{
	[Property] public float BallSpeed { get; set; } = 700f;
	[Property] public float SpeedIncrease { get; set; } = 1.1f;

	private Vector3 velocity;
	private Board board;
	private GameManger game;
	private GameObject lastColsion;

	protected override void OnStart()
	{
		board = Scene.GetAllComponents<Board>().FirstOrDefault();
		game = Scene.GetAllComponents<GameManger>().FirstOrDefault();

		velocity = Vector3.Random;
		velocity.y = 1f;
		velocity.x = 0f;

		Log.Info( velocity );
	}

	protected override void OnUpdate()
	{
		Transform.Position += velocity * BallSpeed * Time.Delta;
	}

	void ITriggerListener.OnTriggerEnter( Collider other )
	{
		if ( other.GameObject == lastColsion ) return;

		lastColsion = other.GameObject;

		if ( lastColsion == board.Left ) game.Score( 0 );
		if ( lastColsion == board.Right ) game.Score( 1 );

		if ( lastColsion == board.Top || lastColsion == board.Bottom )
		{
			velocity.z *= -1;
		}
		if ( lastColsion == board.PaddleLeft || lastColsion == board.PaddleRight )
		{
			velocity.y *= -1f;
			velocity *= SpeedIncrease;
		}
	}

	void ITriggerListener.OnTriggerExit( Collider other ) { }
}
