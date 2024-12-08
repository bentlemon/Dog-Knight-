# Dog Knight! (Course project - TMN114)
## Description
A simple behaviour tree implementation in Unity (2022). Made for the course _Artificial Intelligence for Interactive Media_ at LiU University. 

## Tree setup for Knight Dog
Dog knight has a simple tree setup that is the following:
```
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node> {
                new EnemyInFOVRange(transform),
                new GoToTargetAction(transform),
                new EnemyInAttackRange(transform),
                new AttackAction(transform)
            }),
            new PatrolAction(transform),
        });
```

## Video
Click the following image to see the result! :)

[![Dog Knight Demo Video](https://img.youtube.com/vi/BLsSRWvRAQ4/0.jpg)](https://www.youtube.com/watch?v=BLsSRWvRAQ4)

## 3D Assets used 
- https://assetstore.unity.com/packages/3d/environments/stylized-hand-painted-dungeon-free-173934 
- https://assetstore.unity.com/packages/3d/characters/animals/dog-knight-pbr-polyart-135227 
- https://assetstore.unity.com/packages/3d/characters/animals/insects/fantasy-spider-236418 
- https://assetstore.unity.com/packages/3d/props/crate-31462 
- https://assetstore.unity.com/packages/3d/props/barrels-32975 
