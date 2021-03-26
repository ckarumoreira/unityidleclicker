using UnityEngine;
using UnityEngine.UI;

public class IdleTutorialGame : MonoBehaviour {
    public Text coinsText;
    public Text coinsPerSecondText;
    public Text coinsPerTapText;

    public Text tapUpgradeLevelText;
    public Text turboTapUpgradeLevelText;
    public Text productionUpgradeLevelText;
    public Text turboProductionUpgradeLevelText;

    public Text tapUpgradeCostText;
    public Text turboTapUpgradeCostText;
    public Text productionUpgradeCostText;
    public Text turboProductionUpgradeCostText;

    public Text tapUpgradePowerText;
    public Text turboTapUpgradePowerText;
    public Text productionUpgradePowerText;
    public Text turboProductionUpgradePowerText;

    public Slider cycleMeter;

    public double coins;
    private float timer;

    private UpgradeEngine tapUpgrader;
    private UpgradeEngine turboTapUpgrader;
    private UpgradeEngine productionUpgrader;
    private UpgradeEngine turboProductionUpgrader;

    public void Start() {
        coins = 0;

        tapUpgrader = new UpgradeEngine(
            tapUpgradeCostText,
            tapUpgradeLevelText,
            tapUpgradePowerText,
            10,
            1,
            "+{0} coins"
        );
        productionUpgrader = new UpgradeEngine(
            productionUpgradeCostText,
            productionUpgradeLevelText,
            productionUpgradePowerText,
            25,
            1,
            "+{0} coins/sec"
        );
        turboTapUpgrader = new UpgradeEngine(
            turboTapUpgradeCostText,
            turboTapUpgradeLevelText,
            turboTapUpgradePowerText,
            1000,
            1,
            "+{0} Upgrade Tap power",
            1.25
        );
        turboProductionUpgrader = new UpgradeEngine(
            turboProductionUpgradeCostText,
            turboProductionUpgradeLevelText,
            turboProductionUpgradePowerText,
            2500,
            1,
            "+{0} Upgrade Prod power",
            1.25
        );

        timer = 0f;
        cycleMeter.value = 0;
    }

    public void Update() {
        IncrementCoinsPerSecond();
        coinsText.text = $"Coins: {AbbreviationUtility.AbbreviateNumber(coins)}";
        coinsPerTapText.text = $"+{AbbreviationUtility.AbbreviateNumber(GetCoinsPerTap())} coins";
        coinsPerSecondText.text = $"+{AbbreviationUtility.AbbreviateNumber(GetCoinsPerSecond())} coins/sec";
    }

    public void Tap() {
        coins += GetCoinsPerTap();
    }

    public void UpgradeTap() {
        if (coins < tapUpgrader.Cost)
            return;

        coins -= tapUpgrader.Cost;
        tapUpgrader.Upgrade();
    }

    public void UpgradeTurboTap() {
        if (coins < turboTapUpgrader.Cost)
            return;

        coins -= turboTapUpgrader.Cost;
        turboTapUpgrader.Upgrade();
        tapUpgrader.Power = 1 + (turboTapUpgrader.Power * turboTapUpgrader.Level);
    }

    public void UpgradeProduction() {
        if (coins < productionUpgrader.Cost)
            return;

        coins -= productionUpgrader.Cost;
        productionUpgrader.Upgrade();
    }

    public void UpgradeTurboProduction() {
        if (coins < turboProductionUpgrader.Cost)
            return;

        coins -= turboProductionUpgrader.Cost;
        turboProductionUpgrader.Upgrade();
        productionUpgrader.Power = 1 + (turboProductionUpgrader.Power * turboProductionUpgrader.Level);
    }

    private double GetCoinsPerTap() {
        return 1 + (tapUpgrader.Level * tapUpgrader.Power);
    }

    private double GetCoinsPerSecond() {
        return productionUpgrader.Level * productionUpgrader.Power;
    }

    private void IncrementCoinsPerSecond() {
        timer += Time.deltaTime;
        cycleMeter.value = timer;
        if (timer > 1f) {
            coins += GetCoinsPerSecond();
            timer = 0f;
        }
    }
}