using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootprojectile : MonoBehaviour
{
    [SerializeField] private Transform pfBullet;
    // Start is called before the first frame update
    private void Awake(){
        GetComponent<CharacterAim_Base>().OnShoot += shootprojectile_OnShoot;
    }

    // Update is called once per frame
    private void shootprojectile_OnShoot(object sender, CharacterAim_Base.OnShootEventArgs e)
    {
        
        Transform bulletTransform = Instantiate(pfBullet,e.gunEndPointPosition, Quaternion.identity);
        Vector3 shootDir = (e.shootPosition -e.gunEndPointPosition).normalized;
        bulletTransform.GetComponent<Bullet>() = Setup(shootDir);
        
    }
}
