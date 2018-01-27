using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item
{
    bool is_active();
    void update_player(Player parent);
    void use(GameObject parent, Vector2 direction);
}