# gsws

## How the branches work
#### Unique branch
This is where all development should occur. While developing a piece of functionality, build it in an isolated branch.
#### Development branch
When development of a piece of functionality is complete, merge it into the **Development** branch. New unique branches will pull from this branch, and this is the first place where different pieces of functionality are combined.
#### Compiled branch
Since the Development branch will be inherently unstable, once there is a successful compile in the **Development** branch and the app launch without errors, the **Development** branch can be merged into the **Compiled** branch. Once in this branch, new functionality should be tested rigourosly for stability and quality.
#### Stable branch
When testing is complete in the **Compiled** branch, code can be merged into the **Stable** branch. At that point, code will sit in this branch and tested over time to allow the code to stabilize.
#### Release branch
When the code in the **Stable** branch has stabilized and further rounds of testing are complete, it can be merged into the **Release** branch. This branch should often be identical to the **Main** branch. Code in here should be smoke tested, and this is where new features should be demoed and prepared before release.
#### Main branch
When we are ready to release a new piece of functionality, the **Release** branch will be merged into the **Main** branch, which publishes into the main url for the app.