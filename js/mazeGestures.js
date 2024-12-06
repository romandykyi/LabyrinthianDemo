// A function that defines all maze shape gestures
function createMazeGestures(reader) {
    let gestureFromPatterns = (name, patterns, isCircular = false) => ({
        name: name,
        patterns: patterns,
        normalizeSize: true,
        normalizeTime: true,
        detectCircular: isCircular,
        action: async () => {
            await reader.invokeMethodAsync('SendGestureAsync', name);
        }
    });
    
    return new Gestures({
        msByChar: 50,
        mouseButton: 2, // Right mouse button
        trailStyle: 'line',
        detectCircular: true,
        patterns: [
            gestureFromPatterns("square", ["22220000", "00006666"]),
            gestureFromPatterns("triangle", ["11117777", "1111666"]),
            gestureFromPatterns("triangle-square", ["2222000055555", "0000666633333"]),
            gestureFromPatterns("triangle-hexagon", ["33335555", "33336666"]),
            gestureFromPatterns("circle", ["000111222333444555666777888", "888777666555444333222111000"], true),
            gestureFromPatterns("hexagon", ["11110000"]),
            gestureFromPatterns("hexagon-square", ["00001111"]),
            gestureFromPatterns("octagon", ["66665555", "66667777"]),
            gestureFromPatterns("octagon-diagonal", ["55556666", "77776666"]),
        ]
    });
}

// A function that is called by the Blazor page to initialize gestures
window.initMazeGestures = reader => {
    const gestures = createMazeGestures(reader);
    gestures.install();
};