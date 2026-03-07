#pragma once
#include "base.h"
#include "collision.h"
#include "id.h"
#include "math_functions.h"
#include <stdbool.h>
#include <stdint.h>
#define B2_DEFAULT_CATEGORY_BITS 1
#define B2_DEFAULT_MASK_BITS UINT64_MAX
typedef void b2TaskCallback( int startIndex, int endIndex, uint32_t workerIndex, void* taskContext );
typedef void* b2EnqueueTaskCallback( b2TaskCallback* task, int itemCount, int minRange, void* taskContext, void* userContext );
typedef void b2FinishTaskCallback( void* userTask, void* userContext );
typedef float b2FrictionCallback( float frictionA, uint64_t userMaterialIdA, float frictionB, uint64_t userMaterialIdB );
typedef float b2RestitutionCallback( float restitutionA, uint64_t userMaterialIdA, float restitutionB, uint64_t userMaterialIdB );
typedef struct b2RayResult
{
	b2ShapeId shapeId;
	b2Vec2 point;
	b2Vec2 normal;
	float fraction;
	int nodeVisits;
	int leafVisits;
	bool hit;
} b2RayResult;
typedef struct b2WorldDef
{
	b2Vec2 gravity;
	float restitutionThreshold;
	float hitEventThreshold;
	float contactHertz;
	float contactDampingRatio;
	float contactSpeed;
	float maximumLinearSpeed;
	b2FrictionCallback* frictionCallback;
	b2RestitutionCallback* restitutionCallback;
	bool enableSleep;
	bool enableContinuous;
	bool enableContactSoftening;
	int workerCount;
	b2EnqueueTaskCallback* enqueueTask;
	b2FinishTaskCallback* finishTask;
	void* userTaskContext;
	void* userData;
	int internalValue;
} b2WorldDef;
B2_API b2WorldDef b2DefaultWorldDef( void );
typedef enum b2BodyType
{
	b2_staticBody = 0,
	b2_kinematicBody = 1,
	b2_dynamicBody = 2,
	b2_bodyTypeCount,
} b2BodyType;
typedef struct b2MotionLocks
{
	bool linearX;
	bool linearY;
	bool angularZ;
} b2MotionLocks;
typedef struct b2BodyDef
{
	b2BodyType type;
	b2Vec2 position;
	b2Rot rotation;
	b2Vec2 linearVelocity;
	float angularVelocity;
	float linearDamping;
	float angularDamping;
	float gravityScale;
	float sleepThreshold;
	const char* name;
	void* userData;
	b2MotionLocks motionLocks;
	bool enableSleep;
	bool isAwake;
	bool isBullet;
	bool isEnabled;
	bool allowFastRotation;
	int internalValue;
} b2BodyDef;
B2_API b2BodyDef b2DefaultBodyDef( void );
typedef struct b2Filter
{
	uint64_t categoryBits;
	uint64_t maskBits;
	int groupIndex;
} b2Filter;
B2_API b2Filter b2DefaultFilter( void );
typedef struct b2QueryFilter
{
	uint64_t categoryBits;
	uint64_t maskBits;
} b2QueryFilter;
B2_API b2QueryFilter b2DefaultQueryFilter( void );
typedef enum b2ShapeType
{
	b2_circleShape,
	b2_capsuleShape,
	b2_segmentShape,
	b2_polygonShape,
	b2_chainSegmentShape,
	b2_shapeTypeCount
} b2ShapeType;
typedef struct b2SurfaceMaterial
{
	float friction;
	float restitution;
	float rollingResistance;
	float tangentSpeed;
	uint64_t userMaterialId;
	uint32_t customColor;
} b2SurfaceMaterial;
B2_API b2SurfaceMaterial b2DefaultSurfaceMaterial( void );
typedef struct b2ShapeDef
{
	void* userData;
	b2SurfaceMaterial material;
	float density;
	b2Filter filter;
	bool enableCustomFiltering;
	bool isSensor;
	bool enableSensorEvents;
	bool enableContactEvents;
	bool enableHitEvents;
	bool enablePreSolveEvents;
	bool invokeContactCreation;
	bool updateBodyMass;
	int internalValue;
} b2ShapeDef;
B2_API b2ShapeDef b2DefaultShapeDef( void );
typedef struct b2ChainDef
{
	void* userData;
	const b2Vec2* points;
	int count;
	const b2SurfaceMaterial* materials;
	int materialCount;
	b2Filter filter;
	bool isLoop;
	bool enableSensorEvents;
	int internalValue;
} b2ChainDef;
B2_API b2ChainDef b2DefaultChainDef( void );
typedef struct b2Profile
{
	float step;
	float pairs;
	float collide;
	float solve;
	float prepareStages;
	float solveConstraints;
	float prepareConstraints;
	float integrateVelocities;
	float warmStart;
	float solveImpulses;
	float integratePositions;
	float relaxImpulses;
	float applyRestitution;
	float storeImpulses;
	float splitIslands;
	float transforms;
	float sensorHits;
	float jointEvents;
	float hitEvents;
	float refit;
	float bullets;
	float sleepIslands;
	float sensors;
} b2Profile;
typedef struct b2Counters
{
	int bodyCount;
	int shapeCount;
	int contactCount;
	int jointCount;
	int islandCount;
	int stackUsed;
	int staticTreeHeight;
	int treeHeight;
	int byteCount;
	int taskCount;
	int colorCounts[24];
} b2Counters;
typedef enum b2JointType
{
	b2_distanceJoint,
	b2_filterJoint,
	b2_motorJoint,
	b2_prismaticJoint,
	b2_revoluteJoint,
	b2_weldJoint,
	b2_wheelJoint,
} b2JointType;
typedef struct b2JointDef
{
	void* userData;
	b2BodyId bodyIdA;
	b2BodyId bodyIdB;
	b2Transform localFrameA;
	b2Transform localFrameB;
	float forceThreshold;
	float torqueThreshold;
	float constraintHertz;
	float constraintDampingRatio;
	float drawScale;
	bool collideConnected;
} b2JointDef;
typedef struct b2DistanceJointDef
{
	b2JointDef base;
	float length;
	bool enableSpring;
	float lowerSpringForce;
	float upperSpringForce;
	float hertz;
	float dampingRatio;
	bool enableLimit;
	float minLength;
	float maxLength;
	bool enableMotor;
	float maxMotorForce;
	float motorSpeed;
	int internalValue;
} b2DistanceJointDef;
B2_API b2DistanceJointDef b2DefaultDistanceJointDef( void );
typedef struct b2MotorJointDef
{
	b2JointDef base;
	b2Vec2 linearVelocity;
	float maxVelocityForce;
	float angularVelocity;
	float maxVelocityTorque;
	float linearHertz;
	float linearDampingRatio;
	float maxSpringForce;
	float angularHertz;
	float angularDampingRatio;
	float maxSpringTorque;
	int internalValue;
} b2MotorJointDef;
B2_API b2MotorJointDef b2DefaultMotorJointDef( void );
typedef struct b2FilterJointDef
{
	b2JointDef base;
	int internalValue;
} b2FilterJointDef;
B2_API b2FilterJointDef b2DefaultFilterJointDef( void );
typedef struct b2PrismaticJointDef
{
	b2JointDef base;
	bool enableSpring;
	float hertz;
	float dampingRatio;
	float targetTranslation;
	bool enableLimit;
	float lowerTranslation;
	float upperTranslation;
	bool enableMotor;
	float maxMotorForce;
	float motorSpeed;
	int internalValue;
} b2PrismaticJointDef;
B2_API b2PrismaticJointDef b2DefaultPrismaticJointDef( void );
typedef struct b2RevoluteJointDef
{
	b2JointDef base;
	float targetAngle;
	bool enableSpring;
	float hertz;
	float dampingRatio;
	bool enableLimit;
	float lowerAngle;
	float upperAngle;
	bool enableMotor;
	float maxMotorTorque;
	float motorSpeed;
	int internalValue;
} b2RevoluteJointDef;
B2_API b2RevoluteJointDef b2DefaultRevoluteJointDef( void );
typedef struct b2WeldJointDef
{
	b2JointDef base;
	float linearHertz;
	float angularHertz;
	float linearDampingRatio;
	float angularDampingRatio;
	int internalValue;
} b2WeldJointDef;
B2_API b2WeldJointDef b2DefaultWeldJointDef( void );
typedef struct b2WheelJointDef
{
	b2JointDef base;
	bool enableSpring;
	float hertz;
	float dampingRatio;
	bool enableLimit;
	float lowerTranslation;
	float upperTranslation;
	bool enableMotor;
	float maxMotorTorque;
	float motorSpeed;
	int internalValue;
} b2WheelJointDef;
B2_API b2WheelJointDef b2DefaultWheelJointDef( void );
typedef struct b2ExplosionDef
{
	uint64_t maskBits;
	b2Vec2 position;
	float radius;
	float falloff;
	float impulsePerLength;
} b2ExplosionDef;
B2_API b2ExplosionDef b2DefaultExplosionDef( void );
typedef struct b2SensorBeginTouchEvent
{
	b2ShapeId sensorShapeId;
	b2ShapeId visitorShapeId;
} b2SensorBeginTouchEvent;
typedef struct b2SensorEndTouchEvent
{
	b2ShapeId sensorShapeId;
	b2ShapeId visitorShapeId;
} b2SensorEndTouchEvent;
typedef struct b2SensorEvents
{
	b2SensorBeginTouchEvent* beginEvents;
	b2SensorEndTouchEvent* endEvents;
	int beginCount;
	int endCount;
} b2SensorEvents;
typedef struct b2ContactBeginTouchEvent
{
	b2ShapeId shapeIdA;
	b2ShapeId shapeIdB;
	b2ContactId contactId;
} b2ContactBeginTouchEvent;
typedef struct b2ContactEndTouchEvent
{
	b2ShapeId shapeIdA;
	b2ShapeId shapeIdB;
	b2ContactId contactId;
} b2ContactEndTouchEvent;
typedef struct b2ContactHitEvent
{
	b2ShapeId shapeIdA;
	b2ShapeId shapeIdB;
	b2ContactId contactId;
	b2Vec2 point;
	b2Vec2 normal;
	float approachSpeed;
} b2ContactHitEvent;
typedef struct b2ContactEvents
{
	b2ContactBeginTouchEvent* beginEvents;
	b2ContactEndTouchEvent* endEvents;
	b2ContactHitEvent* hitEvents;
	int beginCount;
	int endCount;
	int hitCount;
} b2ContactEvents;
typedef struct b2BodyMoveEvent
{
	void* userData;
	b2Transform transform;
	b2BodyId bodyId;
	bool fellAsleep;
} b2BodyMoveEvent;
typedef struct b2BodyEvents
{
	b2BodyMoveEvent* moveEvents;
	int moveCount;
} b2BodyEvents;
typedef struct b2JointEvent
{
	b2JointId jointId;
	void* userData;
} b2JointEvent;
typedef struct b2JointEvents
{
	b2JointEvent* jointEvents;
	int count;
} b2JointEvents;
typedef struct b2ContactData
{
	b2ContactId contactId;
	b2ShapeId shapeIdA;
	b2ShapeId shapeIdB;
	b2Manifold manifold;
} b2ContactData;
typedef bool b2CustomFilterFcn( b2ShapeId shapeIdA, b2ShapeId shapeIdB, void* context );
typedef bool b2PreSolveFcn( b2ShapeId shapeIdA, b2ShapeId shapeIdB, b2Vec2 point, b2Vec2 normal, void* context );
typedef bool b2OverlapResultFcn( b2ShapeId shapeId, void* context );
typedef float b2CastResultFcn( b2ShapeId shapeId, b2Vec2 point, b2Vec2 normal, float fraction, void* context );
typedef bool b2PlaneResultFcn( b2ShapeId shapeId, const b2PlaneResult* plane, void* context );
typedef enum b2HexColor
{
	b2_colorAliceBlue = 0xF0F8FF,
	b2_colorAntiqueWhite = 0xFAEBD7,
	b2_colorAqua = 0x00FFFF,
	b2_colorAquamarine = 0x7FFFD4,
	b2_colorAzure = 0xF0FFFF,
	b2_colorBeige = 0xF5F5DC,
	b2_colorBisque = 0xFFE4C4,
	b2_colorBlack = 0x000000,
	b2_colorBlanchedAlmond = 0xFFEBCD,
	b2_colorBlue = 0x0000FF,
	b2_colorBlueViolet = 0x8A2BE2,
	b2_colorBrown = 0xA52A2A,
	b2_colorBurlywood = 0xDEB887,
	b2_colorCadetBlue = 0x5F9EA0,
	b2_colorChartreuse = 0x7FFF00,
	b2_colorChocolate = 0xD2691E,
	b2_colorCoral = 0xFF7F50,
	b2_colorCornflowerBlue = 0x6495ED,
	b2_colorCornsilk = 0xFFF8DC,
	b2_colorCrimson = 0xDC143C,
	b2_colorCyan = 0x00FFFF,
	b2_colorDarkBlue = 0x00008B,
	b2_colorDarkCyan = 0x008B8B,
	b2_colorDarkGoldenRod = 0xB8860B,
	b2_colorDarkGray = 0xA9A9A9,
	b2_colorDarkGreen = 0x006400,
	b2_colorDarkKhaki = 0xBDB76B,
	b2_colorDarkMagenta = 0x8B008B,
	b2_colorDarkOliveGreen = 0x556B2F,
	b2_colorDarkOrange = 0xFF8C00,
	b2_colorDarkOrchid = 0x9932CC,
	b2_colorDarkRed = 0x8B0000,
	b2_colorDarkSalmon = 0xE9967A,
	b2_colorDarkSeaGreen = 0x8FBC8F,
	b2_colorDarkSlateBlue = 0x483D8B,
	b2_colorDarkSlateGray = 0x2F4F4F,
	b2_colorDarkTurquoise = 0x00CED1,
	b2_colorDarkViolet = 0x9400D3,
	b2_colorDeepPink = 0xFF1493,
	b2_colorDeepSkyBlue = 0x00BFFF,
	b2_colorDimGray = 0x696969,
	b2_colorDodgerBlue = 0x1E90FF,
	b2_colorFireBrick = 0xB22222,
	b2_colorFloralWhite = 0xFFFAF0,
	b2_colorForestGreen = 0x228B22,
	b2_colorFuchsia = 0xFF00FF,
	b2_colorGainsboro = 0xDCDCDC,
	b2_colorGhostWhite = 0xF8F8FF,
	b2_colorGold = 0xFFD700,
	b2_colorGoldenRod = 0xDAA520,
	b2_colorGray = 0x808080,
	b2_colorGreen = 0x008000,
	b2_colorGreenYellow = 0xADFF2F,
	b2_colorHoneyDew = 0xF0FFF0,
	b2_colorHotPink = 0xFF69B4,
	b2_colorIndianRed = 0xCD5C5C,
	b2_colorIndigo = 0x4B0082,
	b2_colorIvory = 0xFFFFF0,
	b2_colorKhaki = 0xF0E68C,
	b2_colorLavender = 0xE6E6FA,
	b2_colorLavenderBlush = 0xFFF0F5,
	b2_colorLawnGreen = 0x7CFC00,
	b2_colorLemonChiffon = 0xFFFACD,
	b2_colorLightBlue = 0xADD8E6,
	b2_colorLightCoral = 0xF08080,
	b2_colorLightCyan = 0xE0FFFF,
	b2_colorLightGoldenRodYellow = 0xFAFAD2,
	b2_colorLightGray = 0xD3D3D3,
	b2_colorLightGreen = 0x90EE90,
	b2_colorLightPink = 0xFFB6C1,
	b2_colorLightSalmon = 0xFFA07A,
	b2_colorLightSeaGreen = 0x20B2AA,
	b2_colorLightSkyBlue = 0x87CEFA,
	b2_colorLightSlateGray = 0x778899,
	b2_colorLightSteelBlue = 0xB0C4DE,
	b2_colorLightYellow = 0xFFFFE0,
	b2_colorLime = 0x00FF00,
	b2_colorLimeGreen = 0x32CD32,
	b2_colorLinen = 0xFAF0E6,
	b2_colorMagenta = 0xFF00FF,
	b2_colorMaroon = 0x800000,
	b2_colorMediumAquaMarine = 0x66CDAA,
	b2_colorMediumBlue = 0x0000CD,
	b2_colorMediumOrchid = 0xBA55D3,
	b2_colorMediumPurple = 0x9370DB,
	b2_colorMediumSeaGreen = 0x3CB371,
	b2_colorMediumSlateBlue = 0x7B68EE,
	b2_colorMediumSpringGreen = 0x00FA9A,
	b2_colorMediumTurquoise = 0x48D1CC,
	b2_colorMediumVioletRed = 0xC71585,
	b2_colorMidnightBlue = 0x191970,
	b2_colorMintCream = 0xF5FFFA,
	b2_colorMistyRose = 0xFFE4E1,
	b2_colorMoccasin = 0xFFE4B5,
	b2_colorNavajoWhite = 0xFFDEAD,
	b2_colorNavy = 0x000080,
	b2_colorOldLace = 0xFDF5E6,
	b2_colorOlive = 0x808000,
	b2_colorOliveDrab = 0x6B8E23,
	b2_colorOrange = 0xFFA500,
	b2_colorOrangeRed = 0xFF4500,
	b2_colorOrchid = 0xDA70D6,
	b2_colorPaleGoldenRod = 0xEEE8AA,
	b2_colorPaleGreen = 0x98FB98,
	b2_colorPaleTurquoise = 0xAFEEEE,
	b2_colorPaleVioletRed = 0xDB7093,
	b2_colorPapayaWhip = 0xFFEFD5,
	b2_colorPeachPuff = 0xFFDAB9,
	b2_colorPeru = 0xCD853F,
	b2_colorPink = 0xFFC0CB,
	b2_colorPlum = 0xDDA0DD,
	b2_colorPowderBlue = 0xB0E0E6,
	b2_colorPurple = 0x800080,
	b2_colorRebeccaPurple = 0x663399,
	b2_colorRed = 0xFF0000,
	b2_colorRosyBrown = 0xBC8F8F,
	b2_colorRoyalBlue = 0x4169E1,
	b2_colorSaddleBrown = 0x8B4513,
	b2_colorSalmon = 0xFA8072,
	b2_colorSandyBrown = 0xF4A460,
	b2_colorSeaGreen = 0x2E8B57,
	b2_colorSeaShell = 0xFFF5EE,
	b2_colorSienna = 0xA0522D,
	b2_colorSilver = 0xC0C0C0,
	b2_colorSkyBlue = 0x87CEEB,
	b2_colorSlateBlue = 0x6A5ACD,
	b2_colorSlateGray = 0x708090,
	b2_colorSnow = 0xFFFAFA,
	b2_colorSpringGreen = 0x00FF7F,
	b2_colorSteelBlue = 0x4682B4,
	b2_colorTan = 0xD2B48C,
	b2_colorTeal = 0x008080,
	b2_colorThistle = 0xD8BFD8,
	b2_colorTomato = 0xFF6347,
	b2_colorTurquoise = 0x40E0D0,
	b2_colorViolet = 0xEE82EE,
	b2_colorWheat = 0xF5DEB3,
	b2_colorWhite = 0xFFFFFF,
	b2_colorWhiteSmoke = 0xF5F5F5,
	b2_colorYellow = 0xFFFF00,
	b2_colorYellowGreen = 0x9ACD32,
	b2_colorBox2DRed = 0xDC3132,
	b2_colorBox2DBlue = 0x30AEBF,
	b2_colorBox2DGreen = 0x8CC924,
	b2_colorBox2DYellow = 0xFFEE8C
} b2HexColor;
typedef struct b2DebugDraw
{
	void ( *DrawPolygonFcn )( const b2Vec2* vertices, int vertexCount, b2HexColor color, void* context );
	void ( *DrawSolidPolygonFcn )( b2Transform transform, const b2Vec2* vertices, int vertexCount, float radius, b2HexColor color,
								void* context );
	void ( *DrawCircleFcn )( b2Vec2 center, float radius, b2HexColor color, void* context );
	void ( *DrawSolidCircleFcn )( b2Transform transform, float radius, b2HexColor color, void* context );
	void ( *DrawSolidCapsuleFcn )( b2Vec2 p1, b2Vec2 p2, float radius, b2HexColor color, void* context );
	void ( *DrawLineFcn )( b2Vec2 p1, b2Vec2 p2, b2HexColor color, void* context );
	void ( *DrawTransformFcn )( b2Transform transform, void* context );
	void ( *DrawPointFcn )( b2Vec2 p, float size, b2HexColor color, void* context );
	void ( *DrawStringFcn )( b2Vec2 p, const char* s, b2HexColor color, void* context );
	b2AABB drawingBounds;
	float forceScale;
	float jointScale;
	bool drawShapes;
	bool drawJoints;
	bool drawJointExtras;
	bool drawBounds;
	bool drawMass;
	bool drawBodyNames;
	bool drawContactPoints;
	bool drawGraphColors;
	bool drawContactFeatures;
	bool drawContactNormals;
	bool drawContactForces;
	bool drawFrictionForces;
	bool drawIslands;
	void* context;
} b2DebugDraw;
B2_API b2DebugDraw b2DefaultDebugDraw( void );