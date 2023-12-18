using Sandbox;
using System.Linq;

public sealed class Controller : Component, Component.ITriggerListener
{
	[Property] float Speed { get; set; } = 500;
	[Property] bool Player { get; set; } = true;
	private GameObject top;
	private GameObject bottom;
	private bool canMoveUp = true;
	private bool canMoveDown = true;
	protected override void OnStart()
	{
		var board = GameObject.Parent.Components.Get<Board>();
		top = board.Top; 
		bottom = board.Bottom;
	}
	protected override void OnUpdate()
	{
		Vector3 movement = 0;

		if ( !Player ){ HandleAI(); return;}

		if ( Input.Down( "forward" ) && canMoveUp) movement += Transform.World.Up;
		if ( Input.Down( "backward" ) && canMoveDown) movement += Transform.World.Down;

		var pos = GameObject.Transform.Position + movement * Time.Delta * Speed;
		GameObject.Transform.Position = pos;
	}

	void HandleAI()
	{
		var ball = Scene.GetAllComponents<Ball>().FirstOrDefault();
		if ( ball == null )	return;

		var targetZ = ball.Transform.Position.z;
		var paddleZ = GameObject.Transform.Position.z;
		var distance = GameObject.Transform.Position.Distance( ball.Transform.Position );

		if ( distance >  1150) return;
		if ( targetZ > paddleZ && canMoveUp )
		{
			GameObject.Transform.Position += Transform.World.Up * Time.Delta * Speed;
		}
		if ( targetZ < paddleZ && canMoveDown )
		{
			GameObject.Transform.Position += Transform.World.Down * Time.Delta * Speed;
		}
	}
	void ITriggerListener.OnTriggerEnter( Collider other )
	{
		if( other.GameObject == top ){
			canMoveUp = false;
		}
		if ( other.GameObject == bottom )
		{
			canMoveDown = false;
		}
	}

	void ITriggerListener.OnTriggerExit( Collider other ) 
	{
		if ( other.GameObject == top )
		{
			canMoveUp = true;
		}
		if ( other.GameObject == bottom )
		{
			canMoveDown = true;
		}
	}
}
