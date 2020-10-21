using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S; //Singleton
    [Header("Set in Inspecter")]
    public float minDist = 0.1f;
    private LineRenderer line;
    static public int linecount = 0;
    private List<LineRenderer> lines;
    private GameObject _poi;
    private List<Vector3> points;

    void Awake(){
        S = this;
        line = GetComponent<LineRenderer>();
        //line = new GameObject().AddComponent<LineRenderer>();
        //lines.Add(line);
        line.enabled = false;
        points = new List<Vector3>();
        //print("AWAKEAWAKEAWAKEAWAKE");
    }
    static public int AddCount{
        get{
            return linecount;
        }set{
            linecount++;
        }
    }
    public GameObject poi{
        get{
            return(_poi);
        }set{
            _poi = value;
            if(_poi != null){
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
                //print("POI SET");
            }
        }
    }

    public void Clear(){
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }
    public void AddPoint(){
        Vector3 pt = _poi.transform.position;
        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist){
            return;
            //print("ADD POINT IF 1");
        }
        if(points.Count == 0){
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS;
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            line.enabled = true;
            //print("ADD POINT IF 2");
        }else{
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
            //print("ADD POINT ELSE");
        }
    }
    public Vector3 lastPoint{
        get{
            if(points == null){
                return (Vector3.zero);
                //print("Lastpoint IF");
            }
            return (points[points.Count - 1]);
            //print("lastPoint pt2");
        }
    }
    void FixedUpdate(){
        if(poi == null){
            if(FollowCam.POI != null){
                if(FollowCam.POI.tag == "Projectile"){
                    poi = FollowCam.POI;
                }else{
                    return;
                }
            }else{
                return;
            }
        }
        AddPoint();
        if(FollowCam.POI == null){
            poi = null;
        }
    }
}
