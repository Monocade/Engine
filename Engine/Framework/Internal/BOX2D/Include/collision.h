#pragma once
#include "base.h"
#include "math_functions.h"
#include <stdbool.h>
typedef struct b2SimplexCache b2SimplexCache;
typedef struct b2Hull b2Hull;
#define B2_MAX_POLYGON_VERTICES 8
typedef struct b2RayCastInput
{
	b2Vec2 origin;
	b2Vec2 translation;
	float maxFraction;
} b2RayCastInput;
typedef struct b2ShapeProxy
{
	b2Vec2 points[B2_MAX_POLYGON_VERTICES];
	int count;
	float radius;
} b2ShapeProxy;
typedef struct b2ShapeCastInput
{
	b2ShapeProxy proxy;
	b2Vec2 translation;
	float maxFraction;
	bool canEncroach;
} b2ShapeCastInput;
typedef struct b2CastOutput
{
	b2Vec2 normal;
	b2Vec2 point;
	float fraction;
	int iterations;
	bool hit;
} b2CastOutput;
typedef struct b2MassData
{
	float mass;
	b2Vec2 center;
	float rotationalInertia;
} b2MassData;
typedef struct b2Circle
{
	b2Vec2 center;
	float radius;
} b2Circle;
typedef struct b2Capsule
{
	b2Vec2 center1;
	b2Vec2 center2;
	float radius;
} b2Capsule;
typedef struct b2Polygon
{
	b2Vec2 vertices[B2_MAX_POLYGON_VERTICES];
	b2Vec2 normals[B2_MAX_POLYGON_VERTICES];
	b2Vec2 centroid;
	float radius;
	int count;
} b2Polygon;
typedef struct b2Segment
{
	b2Vec2 point1;
	b2Vec2 point2;
} b2Segment;
typedef struct b2ChainSegment
{
	b2Vec2 ghost1;
	b2Segment segment;
	b2Vec2 ghost2;
	int chainId;
} b2ChainSegment;
B2_API bool b2IsValidRay( const b2RayCastInput* input );
B2_API b2Polygon b2MakePolygon( const b2Hull* hull, float radius );
B2_API b2Polygon b2MakeOffsetPolygon( const b2Hull* hull, b2Vec2 position, b2Rot rotation );
B2_API b2Polygon b2MakeOffsetRoundedPolygon( const b2Hull* hull, b2Vec2 position, b2Rot rotation, float radius );
B2_API b2Polygon b2MakeSquare( float halfWidth );
B2_API b2Polygon b2MakeBox( float halfWidth, float halfHeight );
B2_API b2Polygon b2MakeRoundedBox( float halfWidth, float halfHeight, float radius );
B2_API b2Polygon b2MakeOffsetBox( float halfWidth, float halfHeight, b2Vec2 center, b2Rot rotation );
B2_API b2Polygon b2MakeOffsetRoundedBox( float halfWidth, float halfHeight, b2Vec2 center, b2Rot rotation, float radius );
B2_API b2Polygon b2TransformPolygon( b2Transform transform, const b2Polygon* polygon );
B2_API b2MassData b2ComputeCircleMass( const b2Circle* shape, float density );
B2_API b2MassData b2ComputeCapsuleMass( const b2Capsule* shape, float density );
B2_API b2MassData b2ComputePolygonMass( const b2Polygon* shape, float density );
B2_API b2AABB b2ComputeCircleAABB( const b2Circle* shape, b2Transform transform );
B2_API b2AABB b2ComputeCapsuleAABB( const b2Capsule* shape, b2Transform transform );
B2_API b2AABB b2ComputePolygonAABB( const b2Polygon* shape, b2Transform transform );
B2_API b2AABB b2ComputeSegmentAABB( const b2Segment* shape, b2Transform transform );
B2_API bool b2PointInCircle( const b2Circle* shape, b2Vec2 point );
B2_API bool b2PointInCapsule( const b2Capsule* shape, b2Vec2 point );
B2_API bool b2PointInPolygon( const b2Polygon* shape, b2Vec2 point );
B2_API b2CastOutput b2RayCastCircle( const b2Circle* shape, const b2RayCastInput* input );
B2_API b2CastOutput b2RayCastCapsule( const b2Capsule* shape, const b2RayCastInput* input );
B2_API b2CastOutput b2RayCastSegment( const b2Segment* shape, const b2RayCastInput* input, bool oneSided );
B2_API b2CastOutput b2RayCastPolygon( const b2Polygon* shape, const b2RayCastInput* input );
B2_API b2CastOutput b2ShapeCastCircle(const b2Circle* shape,  const b2ShapeCastInput* input );
B2_API b2CastOutput b2ShapeCastCapsule( const b2Capsule* shape, const b2ShapeCastInput* input);
B2_API b2CastOutput b2ShapeCastSegment( const b2Segment* shape, const b2ShapeCastInput* input );
B2_API b2CastOutput b2ShapeCastPolygon( const b2Polygon* shape, const b2ShapeCastInput* input );
typedef struct b2Hull
{
	b2Vec2 points[B2_MAX_POLYGON_VERTICES];
	int count;
} b2Hull;
B2_API b2Hull b2ComputeHull( const b2Vec2* points, int count );
B2_API bool b2ValidateHull( const b2Hull* hull );
typedef struct b2SegmentDistanceResult
{
	b2Vec2 closest1;
	b2Vec2 closest2;
	float fraction1;
	float fraction2;
	float distanceSquared;
} b2SegmentDistanceResult;
B2_API b2SegmentDistanceResult b2SegmentDistance( b2Vec2 p1, b2Vec2 q1, b2Vec2 p2, b2Vec2 q2 );
typedef struct b2SimplexCache
{
	uint16_t count;
	uint8_t indexA[3];
	uint8_t indexB[3];
} b2SimplexCache;
static const b2SimplexCache b2_emptySimplexCache = B2_ZERO_INIT;
typedef struct b2DistanceInput
{
	b2ShapeProxy proxyA;
	b2ShapeProxy proxyB;
	b2Transform transformA;
	b2Transform transformB;
	bool useRadii;
} b2DistanceInput;
typedef struct b2DistanceOutput
{
	b2Vec2 pointA;	  
	b2Vec2 pointB;	  
	b2Vec2 normal;	  
	float distance;	  
	int iterations;	  
	int simplexCount; 
} b2DistanceOutput;
typedef struct b2SimplexVertex
{
	b2Vec2 wA;	
	b2Vec2 wB;	
	b2Vec2 w;	
	float a;	
	int indexA; 
	int indexB; 
} b2SimplexVertex;
typedef struct b2Simplex
{
	b2SimplexVertex v1, v2, v3; 
	int count;					
} b2Simplex;
B2_API b2DistanceOutput b2ShapeDistance( const b2DistanceInput* input, b2SimplexCache* cache, b2Simplex* simplexes,
										 int simplexCapacity );
typedef struct b2ShapeCastPairInput
{
	b2ShapeProxy proxyA;	
	b2ShapeProxy proxyB;	
	b2Transform transformA; 
	b2Transform transformB; 
	b2Vec2 translationB;	
	float maxFraction;		
	bool canEncroach;		
} b2ShapeCastPairInput;
B2_API b2CastOutput b2ShapeCast( const b2ShapeCastPairInput* input );
B2_API b2ShapeProxy b2MakeProxy( const b2Vec2* points, int count, float radius );
B2_API b2ShapeProxy b2MakeOffsetProxy( const b2Vec2* points, int count, float radius, b2Vec2 position, b2Rot rotation );
typedef struct b2Sweep
{
	b2Vec2 localCenter; 
	b2Vec2 c1;			
	b2Vec2 c2;			
	b2Rot q1;			
	b2Rot q2;			
} b2Sweep;
B2_API b2Transform b2GetSweepTransform( const b2Sweep* sweep, float time );
typedef struct b2TOIInput
{
	b2ShapeProxy proxyA; 
	b2ShapeProxy proxyB; 
	b2Sweep sweepA;		 
	b2Sweep sweepB;		 
	float maxFraction;	 
} b2TOIInput;
typedef enum b2TOIState
{
	b2_toiStateUnknown,
	b2_toiStateFailed,
	b2_toiStateOverlapped,
	b2_toiStateHit,
	b2_toiStateSeparated
} b2TOIState;
typedef struct b2TOIOutput
{
	b2TOIState state;
	b2Vec2 point;
	b2Vec2 normal;
	float fraction;
} b2TOIOutput;
B2_API b2TOIOutput b2TimeOfImpact( const b2TOIInput* input );
typedef struct b2ManifoldPoint
{
	b2Vec2 point;
	b2Vec2 anchorA;
	b2Vec2 anchorB;
	float separation;
	float normalImpulse;
	float tangentImpulse;
	float totalNormalImpulse;
	float normalVelocity;
	uint16_t id;
	bool persisted;
} b2ManifoldPoint;
typedef struct b2Manifold
{
	b2Vec2 normal;
	float rollingImpulse;
	b2ManifoldPoint points[2];
	int pointCount;
} b2Manifold;
B2_API b2Manifold b2CollideCircles( const b2Circle* circleA, b2Transform xfA, const b2Circle* circleB, b2Transform xfB );
B2_API b2Manifold b2CollideCapsuleAndCircle( const b2Capsule* capsuleA, b2Transform xfA, const b2Circle* circleB,
											 b2Transform xfB );
B2_API b2Manifold b2CollideSegmentAndCircle( const b2Segment* segmentA, b2Transform xfA, const b2Circle* circleB,
											 b2Transform xfB );
B2_API b2Manifold b2CollidePolygonAndCircle( const b2Polygon* polygonA, b2Transform xfA, const b2Circle* circleB,
											 b2Transform xfB );
B2_API b2Manifold b2CollideCapsules( const b2Capsule* capsuleA, b2Transform xfA, const b2Capsule* capsuleB, b2Transform xfB );
B2_API b2Manifold b2CollideSegmentAndCapsule( const b2Segment* segmentA, b2Transform xfA, const b2Capsule* capsuleB,
											  b2Transform xfB );
B2_API b2Manifold b2CollidePolygonAndCapsule( const b2Polygon* polygonA, b2Transform xfA, const b2Capsule* capsuleB,
											  b2Transform xfB );
B2_API b2Manifold b2CollidePolygons( const b2Polygon* polygonA, b2Transform xfA, const b2Polygon* polygonB, b2Transform xfB );
B2_API b2Manifold b2CollideSegmentAndPolygon( const b2Segment* segmentA, b2Transform xfA, const b2Polygon* polygonB,
											  b2Transform xfB );
B2_API b2Manifold b2CollideChainSegmentAndCircle( const b2ChainSegment* segmentA, b2Transform xfA, const b2Circle* circleB,
												  b2Transform xfB );
B2_API b2Manifold b2CollideChainSegmentAndCapsule( const b2ChainSegment* segmentA, b2Transform xfA, const b2Capsule* capsuleB,
												   b2Transform xfB, b2SimplexCache* cache );
B2_API b2Manifold b2CollideChainSegmentAndPolygon( const b2ChainSegment* segmentA, b2Transform xfA, const b2Polygon* polygonB,
												   b2Transform xfB, b2SimplexCache* cache );
typedef struct b2DynamicTree
{
	struct b2TreeNode* nodes;
	int root;
	int nodeCount;
	int nodeCapacity;
	int freeList;
	int proxyCount;
	int* leafIndices;
	b2AABB* leafBoxes;
	b2Vec2* leafCenters;
	int* binIndices;
	int rebuildCapacity;
} b2DynamicTree;
typedef struct b2TreeStats
{
	int nodeVisits;
	int leafVisits;
} b2TreeStats;
B2_API b2DynamicTree b2DynamicTree_Create( void );
B2_API void b2DynamicTree_Destroy( b2DynamicTree* tree );
B2_API int b2DynamicTree_CreateProxy( b2DynamicTree* tree, b2AABB aabb, uint64_t categoryBits, uint64_t userData );
B2_API void b2DynamicTree_DestroyProxy( b2DynamicTree* tree, int proxyId );
B2_API void b2DynamicTree_MoveProxy( b2DynamicTree* tree, int proxyId, b2AABB aabb );
B2_API void b2DynamicTree_EnlargeProxy( b2DynamicTree* tree, int proxyId, b2AABB aabb );
B2_API void b2DynamicTree_SetCategoryBits( b2DynamicTree* tree, int proxyId, uint64_t categoryBits );
B2_API uint64_t b2DynamicTree_GetCategoryBits( b2DynamicTree* tree, int proxyId );
typedef bool b2TreeQueryCallbackFcn( int proxyId, uint64_t userData, void* context );
B2_API b2TreeStats b2DynamicTree_Query( const b2DynamicTree* tree, b2AABB aabb, uint64_t maskBits,
										b2TreeQueryCallbackFcn* callback, void* context );
B2_API b2TreeStats b2DynamicTree_QueryAll( const b2DynamicTree* tree, b2AABB aabb, b2TreeQueryCallbackFcn* callback,
										   void* context );
typedef float b2TreeRayCastCallbackFcn( const b2RayCastInput* input, int proxyId, uint64_t userData, void* context );
B2_API b2TreeStats b2DynamicTree_RayCast( const b2DynamicTree* tree, const b2RayCastInput* input, uint64_t maskBits,
										  b2TreeRayCastCallbackFcn* callback, void* context );
typedef float b2TreeShapeCastCallbackFcn( const b2ShapeCastInput* input, int proxyId, uint64_t userData, void* context );
B2_API b2TreeStats b2DynamicTree_ShapeCast( const b2DynamicTree* tree, const b2ShapeCastInput* input, uint64_t maskBits,
											b2TreeShapeCastCallbackFcn* callback, void* context );
B2_API int b2DynamicTree_GetHeight( const b2DynamicTree* tree );
B2_API float b2DynamicTree_GetAreaRatio( const b2DynamicTree* tree );
B2_API b2AABB b2DynamicTree_GetRootBounds( const b2DynamicTree* tree );
B2_API int b2DynamicTree_GetProxyCount( const b2DynamicTree* tree );
B2_API int b2DynamicTree_Rebuild( b2DynamicTree* tree, bool fullBuild );
B2_API int b2DynamicTree_GetByteCount( const b2DynamicTree* tree );
B2_API uint64_t b2DynamicTree_GetUserData( const b2DynamicTree* tree, int proxyId );
B2_API b2AABB b2DynamicTree_GetAABB( const b2DynamicTree* tree, int proxyId );
B2_API void b2DynamicTree_Validate( const b2DynamicTree* tree );
B2_API void b2DynamicTree_ValidateNoEnlarged( const b2DynamicTree* tree );
typedef struct b2PlaneResult
{
	b2Plane plane;
	b2Vec2 point;
	bool hit;
} b2PlaneResult;
typedef struct b2CollisionPlane
{
	b2Plane plane;
	float pushLimit;
	float push;
	bool clipVelocity;
} b2CollisionPlane;
typedef struct b2PlaneSolverResult
{
	b2Vec2 translation;
	int iterationCount;
} b2PlaneSolverResult;
B2_API b2PlaneSolverResult b2SolvePlanes( b2Vec2 targetDelta, b2CollisionPlane* planes, int count );
B2_API b2Vec2 b2ClipVector( b2Vec2 vector, const b2CollisionPlane* planes, int count );