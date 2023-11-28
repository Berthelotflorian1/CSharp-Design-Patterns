class LiasseVierge
{
    private static LiasseVierge instance;

    private LiasseVierge()
    {
    }

    public static LiasseVierge GetInstance()
    {
        if (instance == null)
        {
            instance = new LiasseVierge();
        }
        return instance;
    }
}

