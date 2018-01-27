using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Items
{
    bool is_active();
    void update_player(Player parent);
    void on_drop(Player parent);
    void use(GameObject parent, Vector2 direction);
}