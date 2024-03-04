using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TekeCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    public int _money = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            _money++;
            _moneyText.text = $"Money: {_money}";
            Destroy(collision.gameObject);
        }
    }
}
