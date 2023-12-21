namespace EpsiVal.BusinessLogic.Services;

public static class DecisionTree
{
    public static float GetArrMultiple(float netMargin, float growth, float retention) =>
        netMargin switch
        {
            < 30 => growth switch
            {
                < 10 => retention switch
                {
                    < 90 => 1.6f,
                    <= 95 => 1.7f,
                    _ => 1.8f
                },
                < 35 => retention switch
                {
                    < 90 => 1.9f,
                    <= 95 => 2.0f,
                    _ => 2.1f
                },
                _ => retention switch
                {
                    < 90 => 2.2f,
                    <= 95 => 2.3f,
                    _ => 2.4f
                }
            },
            < 60 => growth switch
            {
                < 10 => retention switch
                {
                    < 90 => 2.0f,
                    <= 95 => 2.21f,
                    _ => 2.42f
                },
                < 35 => retention switch
                {
                    < 90 => 2.63f,
                    <= 95 => 2.84f,
                    _ => 3.05f
                },
                _ => retention switch
                {
                    < 90 => 3.26f,
                    <= 95 => 3.47f,
                    _ => 3.68f
                }
            },
            _ => growth switch
            {
                < 10 => retention switch
                {
                    < 90 => 2.84f,
                    <= 95 => 3.05f,
                    _ => 3.25f
                },
                < 35 => retention switch
                {
                    < 90 => 3.45f,
                    <= 95 => 3.75f,
                    _ => 4.10f
                },
                _ => retention switch
                {
                    < 90 => 4.05f,
                    <= 95 => 4.55f,
                    _ => 4.85f
                }
            }
        };
}