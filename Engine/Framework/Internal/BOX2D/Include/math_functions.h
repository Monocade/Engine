#pragma once
#include "base.h"
#include <float.h>
#include <math.h>
#include <stdbool.h>
typedef struct b2Vec2
{
	float x, y;
} b2Vec2;
typedef struct b2CosSin
{
	float cosine;
	float sine;
} b2CosSin;
typedef struct b2Rot
{
	float c, s;
} b2Rot;
typedef struct b2Transform
{
	b2Vec2 p;
	b2Rot q;
} b2Transform;
typedef struct b2Mat22
{
	b2Vec2 cx, cy;
} b2Mat22;
typedef struct b2AABB
{
	b2Vec2 lowerBound;
	b2Vec2 upperBound;
} b2AABB;
typedef struct b2Plane
{
	b2Vec2 normal;
	float offset;
} b2Plane;
#define B2_PI 3.14159265359f
static const b2Vec2 b2Vec2_zero = { 0.0f, 0.0f };
static const b2Rot b2Rot_identity = { 1.0f, 0.0f };
static const b2Transform b2Transform_identity = { { 0.0f, 0.0f }, { 1.0f, 0.0f } };
static const b2Mat22 b2Mat22_zero = { { 0.0f, 0.0f }, { 0.0f, 0.0f } };
B2_API bool b2IsValidFloat( float a );
B2_API bool b2IsValidVec2( b2Vec2 v );
B2_API bool b2IsValidRotation( b2Rot q );
B2_API bool b2IsValidTransform( b2Transform t );
B2_API bool b2IsValidAABB( b2AABB aabb );
B2_API bool b2IsValidPlane( b2Plane a );
B2_INLINE int b2MinInt( int a, int b )
{
	return a < b ? a : b;
}
B2_INLINE int b2MaxInt( int a, int b )
{
	return a > b ? a : b;
}
B2_INLINE int b2AbsInt( int a )
{
	return a < 0 ? -a : a;
}
B2_INLINE int b2ClampInt( int a, int lower, int upper )
{
	return a < lower ? lower : ( a > upper ? upper : a );
}
B2_INLINE float b2MinFloat( float a, float b )
{
	return a < b ? a : b;
}
B2_INLINE float b2MaxFloat( float a, float b )
{
	return a > b ? a : b;
}
B2_INLINE float b2AbsFloat( float a )
{
	return a < 0 ? -a : a;
}
B2_INLINE float b2ClampFloat( float a, float lower, float upper )
{
	return a < lower ? lower : ( a > upper ? upper : a );
}
B2_API float b2Atan2( float y, float x );
B2_API b2CosSin b2ComputeCosSin( float radians );
B2_INLINE float b2Dot( b2Vec2 a, b2Vec2 b )
{
	return a.x * b.x + a.y * b.y;
}
B2_INLINE float b2Cross( b2Vec2 a, b2Vec2 b )
{
	return a.x * b.y - a.y * b.x;
}
B2_INLINE b2Vec2 b2CrossVS( b2Vec2 v, float s )
{
	return B2_LITERAL( b2Vec2 ){ s * v.y, -s * v.x };
}
B2_INLINE b2Vec2 b2CrossSV( float s, b2Vec2 v )
{
	return B2_LITERAL( b2Vec2 ){ -s * v.y, s * v.x };
}
B2_INLINE b2Vec2 b2LeftPerp( b2Vec2 v )
{
	return B2_LITERAL( b2Vec2 ){ -v.y, v.x };
}
B2_INLINE b2Vec2 b2RightPerp( b2Vec2 v )
{
	return B2_LITERAL( b2Vec2 ){ v.y, -v.x };
}
B2_INLINE b2Vec2 b2Add( b2Vec2 a, b2Vec2 b )
{
	return B2_LITERAL( b2Vec2 ){ a.x + b.x, a.y + b.y };
}
B2_INLINE b2Vec2 b2Sub( b2Vec2 a, b2Vec2 b )
{
	return B2_LITERAL( b2Vec2 ){ a.x - b.x, a.y - b.y };
}
B2_INLINE b2Vec2 b2Neg( b2Vec2 a )
{
	return B2_LITERAL( b2Vec2 ){ -a.x, -a.y };
}
B2_INLINE b2Vec2 b2Lerp( b2Vec2 a, b2Vec2 b, float t )
{
	return B2_LITERAL( b2Vec2 ){ ( 1.0f - t ) * a.x + t * b.x, ( 1.0f - t ) * a.y + t * b.y };
}
B2_INLINE b2Vec2 b2Mul( b2Vec2 a, b2Vec2 b )
{
	return B2_LITERAL( b2Vec2 ){ a.x * b.x, a.y * b.y };
}
B2_INLINE b2Vec2 b2MulSV( float s, b2Vec2 v )
{
	return B2_LITERAL( b2Vec2 ){ s * v.x, s * v.y };
}
B2_INLINE b2Vec2 b2MulAdd( b2Vec2 a, float s, b2Vec2 b )
{
	return B2_LITERAL( b2Vec2 ){ a.x + s * b.x, a.y + s * b.y };
}
B2_INLINE b2Vec2 b2MulSub( b2Vec2 a, float s, b2Vec2 b )
{
	return B2_LITERAL( b2Vec2 ){ a.x - s * b.x, a.y - s * b.y };
}
B2_INLINE b2Vec2 b2Abs( b2Vec2 a )
{
	b2Vec2 b;
	b.x = b2AbsFloat( a.x );
	b.y = b2AbsFloat( a.y );
	return b;
}
B2_INLINE b2Vec2 b2Min( b2Vec2 a, b2Vec2 b )
{
	b2Vec2 c;
	c.x = b2MinFloat( a.x, b.x );
	c.y = b2MinFloat( a.y, b.y );
	return c;
}
B2_INLINE b2Vec2 b2Max( b2Vec2 a, b2Vec2 b )
{
	b2Vec2 c;
	c.x = b2MaxFloat( a.x, b.x );
	c.y = b2MaxFloat( a.y, b.y );
	return c;
}
B2_INLINE b2Vec2 b2Clamp( b2Vec2 v, b2Vec2 a, b2Vec2 b )
{
	b2Vec2 c;
	c.x = b2ClampFloat( v.x, a.x, b.x );
	c.y = b2ClampFloat( v.y, a.y, b.y );
	return c;
}
B2_INLINE float b2Length( b2Vec2 v )
{
	return sqrtf( v.x * v.x + v.y * v.y );
}
B2_INLINE float b2Distance( b2Vec2 a, b2Vec2 b )
{
	float dx = b.x - a.x;
	float dy = b.y - a.y;
	return sqrtf( dx * dx + dy * dy );
}
B2_INLINE b2Vec2 b2Normalize( b2Vec2 v )
{
	float length = sqrtf( v.x * v.x + v.y * v.y );
	if ( length < FLT_EPSILON )
	{
		return B2_LITERAL( b2Vec2 ){ 0.0f, 0.0f };
	}
	float invLength = 1.0f / length;
	b2Vec2 n = { invLength * v.x, invLength * v.y };
	return n;
}
B2_INLINE bool b2IsNormalized( b2Vec2 a )
{
	float aa = b2Dot( a, a );
	return b2AbsFloat( 1.0f - aa ) < 100.0f * FLT_EPSILON;
}
B2_INLINE b2Vec2 b2GetLengthAndNormalize( float* length, b2Vec2 v )
{
	*length = sqrtf( v.x * v.x + v.y * v.y );
	if ( *length < FLT_EPSILON )
	{
		return B2_LITERAL( b2Vec2 ){ 0.0f, 0.0f };
	}
	float invLength = 1.0f / *length;
	b2Vec2 n = { invLength * v.x, invLength * v.y };
	return n;
}
B2_INLINE b2Rot b2NormalizeRot( b2Rot q )
{
	float mag = sqrtf( q.s * q.s + q.c * q.c );
	float invMag = mag > 0.0f ? 1.0f / mag : 0.0f;
	b2Rot qn = { q.c * invMag, q.s * invMag };
	return qn;
}
B2_INLINE b2Rot b2IntegrateRotation( b2Rot q1, float deltaAngle )
{
	b2Rot q2 = { q1.c - deltaAngle * q1.s, q1.s + deltaAngle * q1.c };
	float mag = sqrtf( q2.s * q2.s + q2.c * q2.c );
	float invMag = mag > 0.0f ? 1.0f / mag : 0.0f;
	b2Rot qn = { q2.c * invMag, q2.s * invMag };
	return qn;
}
B2_INLINE float b2LengthSquared( b2Vec2 v )
{
	return v.x * v.x + v.y * v.y;
}
B2_INLINE float b2DistanceSquared( b2Vec2 a, b2Vec2 b )
{
	b2Vec2 c = { b.x - a.x, b.y - a.y };
	return c.x * c.x + c.y * c.y;
}
B2_INLINE b2Rot b2MakeRot( float radians )
{
	b2CosSin cs = b2ComputeCosSin( radians );
	return B2_LITERAL( b2Rot ){ cs.cosine, cs.sine };
}
B2_INLINE b2Rot b2MakeRotFromUnitVector( b2Vec2 unitVector )
{
	B2_ASSERT( b2IsNormalized( unitVector ) );
	return B2_LITERAL( b2Rot ){ unitVector.x, unitVector.y };
}
B2_API b2Rot b2ComputeRotationBetweenUnitVectors( b2Vec2 v1, b2Vec2 v2 );
B2_INLINE bool b2IsNormalizedRot( b2Rot q )
{
	float qq = q.s * q.s + q.c * q.c;
	return 1.0f - 0.0006f < qq && qq < 1.0f + 0.0006f;
}
B2_INLINE b2Rot b2InvertRot( b2Rot a )
{
	return B2_LITERAL( b2Rot ){
		.c = a.c,
		.s = -a.s,
	};
}
B2_INLINE b2Rot b2NLerp( b2Rot q1, b2Rot q2, float t )
{
	float omt = 1.0f - t;
	b2Rot q = {
		omt * q1.c + t * q2.c,
		omt * q1.s + t * q2.s,
	};
	float mag = sqrtf( q.s * q.s + q.c * q.c );
	float invMag = mag > 0.0f ? 1.0f / mag : 0.0f;
	b2Rot qn = { q.c * invMag, q.s * invMag };
	return qn;
}
B2_INLINE float b2ComputeAngularVelocity( b2Rot q1, b2Rot q2, float inv_h )
{
	float omega = inv_h * ( q2.s * q1.c - q2.c * q1.s );
	return omega;
}
B2_INLINE float b2Rot_GetAngle( b2Rot q )
{
	return b2Atan2( q.s, q.c );
}
B2_INLINE b2Vec2 b2Rot_GetXAxis( b2Rot q )
{
	b2Vec2 v = { q.c, q.s };
	return v;
}
B2_INLINE b2Vec2 b2Rot_GetYAxis( b2Rot q )
{
	b2Vec2 v = { -q.s, q.c };
	return v;
}
B2_INLINE b2Rot b2MulRot( b2Rot q, b2Rot r )
{
	b2Rot qr;
	qr.s = q.s * r.c + q.c * r.s;
	qr.c = q.c * r.c - q.s * r.s;
	return qr;
}
B2_INLINE b2Rot b2InvMulRot( b2Rot a, b2Rot b )
{
	b2Rot r;
	r.s = a.c * b.s - a.s * b.c;
	r.c = a.c * b.c + a.s * b.s;
	return r;
}
B2_INLINE float b2RelativeAngle( b2Rot a, b2Rot b )
{
	float s = a.c * b.s - a.s * b.c;
	float c = a.c * b.c + a.s * b.s;
	return b2Atan2( s, c );
}
B2_INLINE float b2UnwindAngle( float radians )
{
	return remainderf( radians, 2.0f * B2_PI );
}
B2_INLINE b2Vec2 b2RotateVector( b2Rot q, b2Vec2 v )
{
	return B2_LITERAL( b2Vec2 ){ q.c * v.x - q.s * v.y, q.s * v.x + q.c * v.y };
}
B2_INLINE b2Vec2 b2InvRotateVector( b2Rot q, b2Vec2 v )
{
	return B2_LITERAL( b2Vec2 ){ q.c * v.x + q.s * v.y, -q.s * v.x + q.c * v.y };
}
B2_INLINE b2Vec2 b2TransformPoint( b2Transform t, const b2Vec2 p )
{
	float x = ( t.q.c * p.x - t.q.s * p.y ) + t.p.x;
	float y = ( t.q.s * p.x + t.q.c * p.y ) + t.p.y;
	return B2_LITERAL( b2Vec2 ){ x, y };
}
B2_INLINE b2Vec2 b2InvTransformPoint( b2Transform t, const b2Vec2 p )
{
	float vx = p.x - t.p.x;
	float vy = p.y - t.p.y;
	return B2_LITERAL( b2Vec2 ){ t.q.c * vx + t.q.s * vy, -t.q.s * vx + t.q.c * vy };
}
B2_INLINE b2Transform b2MulTransforms( b2Transform A, b2Transform B )
{
	b2Transform C;
	C.q = b2MulRot( A.q, B.q );
	C.p = b2Add( b2RotateVector( A.q, B.p ), A.p );
	return C;
}
B2_INLINE b2Transform b2InvMulTransforms( b2Transform A, b2Transform B )
{
	b2Transform C;
	C.q = b2InvMulRot( A.q, B.q );
	C.p = b2InvRotateVector( A.q, b2Sub( B.p, A.p ) );
	return C;
}
B2_INLINE b2Vec2 b2MulMV( b2Mat22 A, b2Vec2 v )
{
	b2Vec2 u = {
		A.cx.x * v.x + A.cy.x * v.y,
		A.cx.y * v.x + A.cy.y * v.y,
	};
	return u;
}
B2_INLINE b2Mat22 b2GetInverse22( b2Mat22 A )
{
	float a = A.cx.x, b = A.cy.x, c = A.cx.y, d = A.cy.y;
	float det = a * d - b * c;
	if ( det != 0.0f )
	{
		det = 1.0f / det;
	}
	b2Mat22 B = {
		{ det * d, -det * c },
		{ -det * b, det * a },
	};
	return B;
}
B2_INLINE b2Vec2 b2Solve22( b2Mat22 A, b2Vec2 b )
{
	float a11 = A.cx.x, a12 = A.cy.x, a21 = A.cx.y, a22 = A.cy.y;
	float det = a11 * a22 - a12 * a21;
	if ( det != 0.0f )
	{
		det = 1.0f / det;
	}
	b2Vec2 x = { det * ( a22 * b.x - a12 * b.y ), det * ( a11 * b.y - a21 * b.x ) };
	return x;
}
B2_INLINE bool b2AABB_Contains( b2AABB a, b2AABB b )
{
	bool s = true;
	s = s && a.lowerBound.x <= b.lowerBound.x;
	s = s && a.lowerBound.y <= b.lowerBound.y;
	s = s && b.upperBound.x <= a.upperBound.x;
	s = s && b.upperBound.y <= a.upperBound.y;
	return s;
}
B2_INLINE b2Vec2 b2AABB_Center( b2AABB a )
{
	b2Vec2 b = { 0.5f * ( a.lowerBound.x + a.upperBound.x ), 0.5f * ( a.lowerBound.y + a.upperBound.y ) };
	return b;
}
B2_INLINE b2Vec2 b2AABB_Extents( b2AABB a )
{
	b2Vec2 b = { 0.5f * ( a.upperBound.x - a.lowerBound.x ), 0.5f * ( a.upperBound.y - a.lowerBound.y ) };
	return b;
}
B2_INLINE b2AABB b2AABB_Union( b2AABB a, b2AABB b )
{
	b2AABB c;
	c.lowerBound.x = b2MinFloat( a.lowerBound.x, b.lowerBound.x );
	c.lowerBound.y = b2MinFloat( a.lowerBound.y, b.lowerBound.y );
	c.upperBound.x = b2MaxFloat( a.upperBound.x, b.upperBound.x );
	c.upperBound.y = b2MaxFloat( a.upperBound.y, b.upperBound.y );
	return c;
}
B2_INLINE bool b2AABB_Overlaps( b2AABB a, b2AABB b )
{
	return !( b.lowerBound.x > a.upperBound.x || b.lowerBound.y > a.upperBound.y || a.lowerBound.x > b.upperBound.x ||
			  a.lowerBound.y > b.upperBound.y );
}
B2_INLINE b2AABB b2MakeAABB( const b2Vec2* points, int count, float radius )
{
	B2_ASSERT( count > 0 );
	b2AABB a = { points[0], points[0] };
	for ( int i = 1; i < count; ++i )
	{
		a.lowerBound = b2Min( a.lowerBound, points[i] );
		a.upperBound = b2Max( a.upperBound, points[i] );
	}
	b2Vec2 r = { radius, radius };
	a.lowerBound = b2Sub( a.lowerBound, r );
	a.upperBound = b2Add( a.upperBound, r );
	return a;
}
B2_INLINE float b2PlaneSeparation( b2Plane plane, b2Vec2 point )
{
	return b2Dot( plane.normal, point ) - plane.offset;
}
B2_INLINE float b2SpringDamper( float hertz, float dampingRatio, float position, float velocity, float timeStep )
{
	float omega = 2.0f * B2_PI * hertz;
	float omegaH = omega * timeStep;
	return ( velocity - omega * omegaH * position ) / ( 1.0f + 2.0f * dampingRatio * omegaH + omegaH * omegaH );
}
B2_API void b2SetLengthUnitsPerMeter( float lengthUnits );
B2_API float b2GetLengthUnitsPerMeter( void );
#ifdef __cplusplus
inline void operator+=( b2Vec2& a, b2Vec2 b )
{
	a.x += b.x;
	a.y += b.y;
}
inline void operator-=( b2Vec2& a, b2Vec2 b )
{
	a.x -= b.x;
	a.y -= b.y;
}
inline void operator*=( b2Vec2& a, float b )
{
	a.x *= b;
	a.y *= b;
}
inline b2Vec2 operator-( b2Vec2 a )
{
	return { -a.x, -a.y };
}
inline b2Vec2 operator+( b2Vec2 a, b2Vec2 b )
{
	return { a.x + b.x, a.y + b.y };
}
inline b2Vec2 operator-( b2Vec2 a, b2Vec2 b )
{
	return { a.x - b.x, a.y - b.y };
}
inline b2Vec2 operator*( float a, b2Vec2 b )
{
	return { a * b.x, a * b.y };
}
inline b2Vec2 operator*( b2Vec2 a, float b )
{
	return { a.x * b, a.y * b };
}
inline bool operator==( b2Vec2 a, b2Vec2 b )
{
	return a.x == b.x && a.y == b.y;
}
inline bool operator!=( b2Vec2 a, b2Vec2 b )
{
	return a.x != b.x || a.y != b.y;
}
#endif