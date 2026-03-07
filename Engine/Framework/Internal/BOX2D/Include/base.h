#pragma once
#include <stdint.h>
#if defined( _MSC_VER ) && defined( box2d_EXPORTS )
	#define BOX2D_EXPORT __declspec( dllexport )
#elif defined( _MSC_VER ) && defined( BOX2D_DLL )
	#define BOX2D_EXPORT __declspec( dllimport )
#elif defined( box2d_EXPORTS )
	#define BOX2D_EXPORT __attribute__( ( visibility( "default" ) ) )
#else
	#define BOX2D_EXPORT
#endif
#ifdef __cplusplus
	#define B2_API extern "C" BOX2D_EXPORT
	#define B2_INLINE inline
	#define B2_LITERAL(T) T
	#define B2_ZERO_INIT {}
#else
	#define B2_API BOX2D_EXPORT
	#define B2_INLINE static inline
	#define B2_LITERAL(T) (T)
	#define B2_ZERO_INIT {0}
#endif
typedef void* b2AllocFcn( unsigned int size, int alignment );
typedef void b2FreeFcn( void* mem, unsigned int size );
typedef int b2AssertFcn( const char* condition, const char* fileName, int lineNumber );
typedef void b2LogFcn( const char* message );
B2_API void b2SetAllocator( b2AllocFcn* allocFcn, b2FreeFcn* freeFcn );
B2_API int b2GetByteCount( void );
B2_API void b2SetAssertFcn( b2AssertFcn* assertFcn );
B2_API void b2SetLogFcn( b2LogFcn* logFcn );
typedef struct b2Version
{
	int major;
	int minor;
	int revision;
} b2Version;
B2_API b2Version b2GetVersion( void );
#if defined( _MSC_VER )
#define B2_BREAKPOINT __debugbreak()
#elif defined( __GNUC__ ) || defined( __clang__ )
#define B2_BREAKPOINT __builtin_trap()
#else
#include <assert.h>
#define B2_BREAKPOINT assert( 0 )
#endif
#if !defined( NDEBUG ) || defined( B2_ENABLE_ASSERT )
B2_API int b2InternalAssertFcn( const char* condition, const char* fileName, int lineNumber );
#define B2_ASSERT( condition )                                                                                                   \
	do                                                                                                                           \
	{                                                                                                                            \
		if ( !( condition ) && b2InternalAssertFcn( #condition, __FILE__, (int)__LINE__ ) )                                          \
			B2_BREAKPOINT;                                                                                                       \
	}                                                                                                                            \
	while ( 0 )
#else
#define B2_ASSERT( ... ) ( (void)0 )
#endif
B2_API uint64_t b2GetTicks( void );
B2_API float b2GetMilliseconds( uint64_t ticks );
B2_API float b2GetMillisecondsAndReset( uint64_t* ticks );
B2_API void b2Yield( void );
#define B2_HASH_INIT 5381
B2_API uint32_t b2Hash( uint32_t hash, const uint8_t* data, int count );