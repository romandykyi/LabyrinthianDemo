namespace LabyrinthianDemo.Math;

public static class MathHelper
{
	public static float Lerp(float min, float max, float t)
	{
		return min * (1f - t) + max * t;
	}
	public static double Lerp(double min, double max, double t)
	{
		return min * (1.0 - t) + max * t;
	}

	public static float LerpBias(float min, float max, float t)
	{
		return t >= 0.5f ? 
			Lerp(1f, max, (t - 0.5f) * 2f) : 
			Lerp(min, 1f, t * 2f);
	}
}
