public class Grass : Plant
{
    public override void Collect()
    {
        ParentBed.currentPlant = null;
        Score.Instance.AddXp(Settings.XP);
        Destroy(gameObject);
    }

    public override void OnGrown()
    {
        isCollectable = true;
    }
}