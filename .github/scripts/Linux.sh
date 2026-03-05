#!/usr/bin/env bash
set -e

echo "Building... OS: $OS PLATFORM: $PLATFORM ARCH: $ARCH RID: $RID"

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
NATIVES_DIR="$BASE_DIR/../../Natives"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"
rm -rf "$NATIVES_DIR"
mkdir -p "$NATIVES_DIR"

MODULES=("BOX2D" "IMGUI" "SDL" "SDL_IMAGE" "SDL_MIXER" "SDL_TTF")

ENVIRONMENT()
{
  echo "Setting up linux environment..."
  
  export CC="gcc"
  export CXX="g++"

  sudo apt-get update
  sudo apt-get install -y \
      build-essential git make pkg-config cmake ninja-build \
      libx11-dev libxext-dev libxrandr-dev libxcursor-dev libxi-dev libxinerama-dev \
      libxfixes-dev libxss-dev libxtst-dev libxkbcommon-dev libdrm-dev libgbm-dev \
      libgl1-mesa-dev libgles2-mesa-dev libegl1-mesa-dev \
      libasound2-dev libpulse-dev libaudio-dev libfribidi-dev libjack-dev libsndio-dev \
      libdbus-1-dev libibus-1.0-dev libudev-dev libpipewire-0.3-dev libwayland-dev \
      libdecor-0-dev liburing-dev
}

BOX2D()
{
  Github "BOX2D" "https://github.com/erincatto/box2d.git" ""
  
  cd "$MODULES_DIR/BOX2D" || exit
  BUILDPATH="$MODULES_DIR/BOX2D/build_$RID"
  INSTALLPATH="$MODULES_DIR/BOX2D/install_$RID"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_COMPILER=$CC \
    -DCMAKE_CXX_COMPILER=$CXX \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DBUILD_SHARED_LIBS=ON \
    -DBOX2D_SAMPLES=OFF \
    -DBOX2D_DOCS=OFF \
    -DBOX2D_BENCHMARKS=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"

  cmake --build . --config Release
  cmake --install . --config Release
  
  find "$INSTALLPATH" -type f \( -name "*.so" -o -name "*.dylib" -o -name "*.dll" \)
}

IMGUI()
{
  Github "IMGUI" "https://github.com/cimgui/cimgui.git" ""
  
  cd "$MODULES_DIR/IMGUI" || exit
  BUILDPATH="$MODULES_DIR/IMGUI/build_$RID"
  INSTALLPATH="$MODULES_DIR/IMGUI/install_$RID"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_COMPILER=$CC \
    -DCMAKE_CXX_COMPILER=$CXX \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DIMGUI_STATIC=no \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/cimgui.so" "$NATIVES_DIR/$RID/cimgui.so"
}

SDL()
{
  Github "SDL" "https://github.com/libsdl-org/SDL.git" ""
  
  cd "$MODULES_DIR/SDL" || exit
  BUILDPATH="$MODULES_DIR/SDL/build_$RID"
  INSTALLPATH="$MODULES_DIR/SDL/install_$RID"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_COMPILER=$CC \
    -DCMAKE_CXX_COMPILER=$CXX \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DSDL_TEST_LIBRARY=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3.so" "$NATIVES_DIR/$RID/libSDL3.so"
}

SDL_IMAGE()
{
  Github "SDL_IMAGE" "https://github.com/libsdl-org/SDL_image.git" ""
  
  cd "$MODULES_DIR/SDL_IMAGE" || exit
  BUILDPATH="$MODULES_DIR/SDL_IMAGE/build_$RID"
  INSTALLPATH="$MODULES_DIR/SDL_IMAGE/install_$RID"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_COMPILER=$CC \
    -DCMAKE_CXX_COMPILER=$CXX \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DSDLIMAGE_BMP=ON \
    -DSDLIMAGE_JPG=ON \
    -DSDLIMAGE_PNG=ON \
    -DSDLIMAGE_WEBP=ON \
    -DSDLIMAGE_AVIF=OFF \
    -DSDLIMAGE_GIF=OFF \
    -DSDLIMAGE_JXL=OFF \
    -DSDLIMAGE_LBM=OFF \
    -DSDLIMAGE_PCX=OFF \
    -DSDLIMAGE_PNM=OFF \
    -DSDLIMAGE_QOI=OFF \
    -DSDLIMAGE_SVG=OFF \
    -DSDLIMAGE_TGA=OFF \
    -DSDLIMAGE_TIF=OFF \
    -DSDLIMAGE_XCF=OFF \
    -DSDLIMAGE_XPM=OFF \
    -DSDLIMAGE_XV=OFF \
    -DSDLIMAGE_PNG_LIBPNG=OFF \
    -DSDLIMAGE_ANI=OFF \
    -DSDLIMAGE_TESTS=OFF \
    -DSDLIMAGE_VENDORED=ON \
    -DSDLIMAGE_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$RID/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_image.so" "$NATIVES_DIR/$RID/libSDL3_image.so"
}

SDL_MIXER()
{
  Github "SDL_MIXER" "https://github.com/libsdl-org/SDL_mixer.git" ""
  
  cd "$MODULES_DIR/SDL_MIXER" || exit
  BUILDPATH="$MODULES_DIR/SDL_MIXER/build_$RID"
  INSTALLPATH="$MODULES_DIR/SDL_MIXER/install_$RID"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_COMPILER=$CC \
    -DCMAKE_CXX_COMPILER=$CXX \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DSDLMIXER_MP3_DRMP3=ON \
    -DSDLMIXER_VORBIS_STB=ON \
    -DSDLMIXER_WAVE=ON \
    -DSDLMIXER_VORBIS_VORBISFILE=OFF \
    -DSDLMIXER_VORBIS_TREMOR=OFF \
    -DSDLMIXER_MIDI_TIMIDITY=OFF \
    -DSDLMIXER_FLAC_LIBFLAC=OFF \
    -DSDLMIXER_FLAC_DRFLAC=OFF \
    -DSDLMIXER_MP3_MPG123=OFF \
    -DSDLMIXER_GME_SHARED=OFF \
    -DSDLMIXER_MOD_XMP=OFF \
    -DSDLMIXER_WAVPACK=OFF \
    -DSDLMIXER_AIFF=OFF \
    -DSDLMIXER_OPUS=OFF \
    -DSDLMIXER_VOC=OFF \
    -DSDLMIXER_GME=OFF \
    -DSDLMIXER_AU=OFF \
    -DSDLMIXER_TESTS=OFF \
    -DSDLMIXER_VENDORED=ON \
    -DSDLMIXER_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$RID/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_mixer.so" "$NATIVES_DIR/$RID/libSDL3_mixer.so"
}

SDL_TTF()
{
  Github "SDL_TTF" "https://github.com/libsdl-org/SDL_ttf.git" ""
  
  cd "$MODULES_DIR/SDL_TTF" || exit
  BUILDPATH="$MODULES_DIR/SDL_TTF/build_$RID"
  INSTALLPATH="$MODULES_DIR/SDL_TTF/install_$RID"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_COMPILER=$CC \
    -DCMAKE_CXX_COMPILER=$CXX \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DSDLTTF_VENDORED=ON \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$RID/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_ttf.so" "$NATIVES_DIR/$RID/libSDL3_ttf.so"
}

COMPLETE()
{
  echo "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"