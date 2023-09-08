# MonoGame-DesktopGL-Glenz
DesktopGL shows quad triangle split (triangles do not align) under the following:
- DesktopGLm not WndowsDX
- rendering to Render Target, not backbuffer
- color is see-through (alpha != 255).
- RenderTarget2D has:
  - preferredDepthFormat != DepthFormat.None
  - preferredMultiSampleCount == 1
  
However, I only see the triangle split in Xona System 8.
In this minimal repro code, the glitch merely doesn't render anything at all!
