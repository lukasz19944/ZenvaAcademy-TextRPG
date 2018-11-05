﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG {
    public class World : MonoBehaviour {
        public Room[,] Dungeon { get; set; }
        public Vector2 grid;

        private void Awake() {
            Dungeon = new Room[(int)grid.x, (int)grid.y];
            StartCoroutine(GenerateFloor());
        }

        public IEnumerator GenerateFloor() {
            for (int x = 0; x < grid.x; x++) {
                for (int y = 0; y < grid.y; y++) {
                    Dungeon[x, y] = new Room() {
                        RoomIndex = new Vector2(x, y)
                    };
                }
            }

            yield return new WaitForSeconds(2f);

            Vector2 exitLocation = new Vector2((int)Random.Range(0, grid.x), (int)Random.Range(0, grid.y));
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].Exit = true;
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].Empty = false;

            Debug.Log("Exit is at: " + exitLocation);
        }
    }
}
