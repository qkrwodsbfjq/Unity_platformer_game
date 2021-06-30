//==========================================
// writer : 노현석.
// file : SlowGround.cs.
// content : 슬로우장판 이펙트 첨가용, 여기서 실제 슬로우 장판 효과와 관련한 스크립트 없음, FeetCollider쪽 참조.
// discript : 그리드 포지션마다 파티클 효과 instantiate.
// 참조 : Start 부분은 몽땅 긁어온거라... 꼬이면 어떻게 대응해야할지 모르겠다.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SlowGround : MonoBehaviour
{
    [SerializeField] ParticleSystem SlowGroundParticles; //요게 파티클효과.
    Tilemap placeholderTilemap = null;
    public List<Vector3> gridPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        placeholderTilemap = transform.GetComponent<Tilemap>();
        for(var n = placeholderTilemap.cellBounds.xMin; n<placeholderTilemap.cellBounds.xMax; n++)
        {
            for(var p = placeholderTilemap.cellBounds.yMin; p<placeholderTilemap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)placeholderTilemap.transform.position.y);
                Vector3 place = placeholderTilemap.CellToWorld(localPlace);
                float newXPos = Convert.ToSingle(localPlace.x) + 0.5f;
                Vector3 newPlace = new Vector3(newXPos, localPlace.y, localPlace.z);
                if (placeholderTilemap.HasTile(localPlace))
                {
                    gridPositions.Add(newPlace);
                }
                else
                {

                }
            }
        }
        foreach(Vector3 positions in gridPositions)
        {
            var newParticles = Instantiate(SlowGroundParticles, new Vector2(positions.x, positions.y), Quaternion.identity);
            newParticles.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
