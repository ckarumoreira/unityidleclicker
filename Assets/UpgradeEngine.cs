using System;
using UnityEngine.UI;

public class UpgradeEngine {
    private double _cost;
    private ulong _level;
    private double _power;
    private string _powerStringFormat;
    private double _costModifier;

    public UpgradeEngine(Text costText, Text levelText, Text powerText, double initialCost, double initialPower, string powerStringFormat, double costModifier = 1.07) {
        _powerStringFormat = powerStringFormat;
        _costModifier = costModifier;

        CostText = costText;
        LevelText = levelText;
        PowerText = powerText;

        Cost = initialCost;
        Power = initialPower;
        Level = 0;
    }

    public Text CostText { get; set; }
    public Text LevelText { get; set; }
    public Text PowerText { get; set; }

    public double Cost {
        get { return _cost; }
        set {
            _cost = value;
            CostText.text = $"Cost: {AbbreviationUtility.AbbreviateNumber(Cost)}";
        }
    }

    public ulong Level {
        get { return _level; }
        set {
            _level = value;
            LevelText.text = $"Level {AbbreviationUtility.AbbreviateNumber(Level)}";
        }
    }

    public double Power {
        get { return _power; }
        set {
            _power = value;
            PowerText.text = string.Format(_powerStringFormat, AbbreviationUtility.AbbreviateNumber(Power));
        }
    }

    public void Upgrade() {
        Level += 1;
        Cost = Math.Ceiling(Cost * _costModifier);
    }
}