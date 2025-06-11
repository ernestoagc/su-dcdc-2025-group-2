# SOLAR_XR

## Explore the benifits of the solar panels with real-time statistics for your house in Mixed Reality!

## Introduction

This project is a Mixed Reality project about **Solar Panels** and their efficientency and benifits specificlly for your location

---

## Design Process

The Design Process started with a **brainstorming session**, where each of us focused on ideas to create immersive project, following **Digital Twins** concept.

<img src="vr-unity/readme/brainstorm.png" width="600" />  

---

### Environment

...

<img src="vr-unity/readme/classroom_scene.jpg" width="600" />  

---

### User Testing

The demo version of the experience was presented and tested by several people, providing us valuable feedback to improve the experience. Based on this feedback, we adjusted our presentation of how the experience would look, as well as made minor changes to gameplay and UI elements (such as the Menu) to make the experience smoother for users.

---

## System Description

### Features

Solar_XR includes the following features:

- A **virtual classroom environment** where users can control their surroundings, such as adjusting the level of sound, light flickering, and controlling people’s movements.
- An **easily accessible intuitive emergency button** that leads users to the Safe Space if they feel uncomfortable and wish to stop the experience.
- **Simulation of people walking near you**, where vibration motors activate when people walk close to you.

---

### Features Decisions

- Hand tracking was chosen over Controllers in order to simplify it for inexperienced users and to make it feel more natural.
- Stationary Environment was decided on in order to reduce risk of motion sickness and because enabling movement provides no benefit to the experience at the moment with current version.
- Button on chest was chosen to provide an intuitive tap out button, which can be a faster way to exit the experience when people get nervous.
- Menu panel - The menu was initially put in front of the user, and they could activate by poking the left hand. Two problems occurred during testing, one that the users would spend most of the experience with menu activated, that would cover most of the screen and ruin the experience. Another one was having difficulties to pinch effectively, without spending a lot of time on it. This becomes a problem, especially when people start to panic.
- Poke - this decision was chosen after user testing, poking feels more natural and it is easier interaction for unexperienced people. Pinch was another interaction that was tested and used at the beginning. Removing pinch and changing it to poke also makes more sense as the participants get used to poke interaction before the experience starts, and having the same interaction throughout whole experience ensures that the users are quick and comfortable.

---

#### Watch the DEMO VIDEO or try out the live version by [this GitHub Repository](https://github.com/ernestoagc/su-det-2025-group-1)

---

## Installation

To install and run "SolarXR", follow the instructions below.

### Software

 **1. Setting Up Unity Hub** 
Download and install Unity Hub from [official page](https://unity.com/download)

**2. Installing Unity Editor and Required Modules**
In Unity Hub, go to the 'Installs' tab and click on the 'Add' button to install a new version of the Unity Editor. Select Unity Editor LTS version 2022.3.56f1
Also, during the installation setup, you should select the following options: 
- Microsoft Visual Studio IDE (for code editing). 
- Android Build Support 

  <img src="vr-unity/readme/unity-installation.png" width="600" />


**3. Configuring  Unity Project**  
**a. Import the Meta XR SDK:**  
- Navigate to Window > Package Manager.
- Click the '+' icon and select 'Add package by name'.
- Enter 'com.meta.xr.sdk.all' and click 'Add'. Restart Unity if prompted.
- The version used in this project was 71.0.0

  <img src="vr-unity/readme/unity-import-sdk.png" width="600" />


**b. Build Setting Configuration:**  
 - Go to File > Build Settings 
 - select 'Android' as the target platform. 
 - Click 'Switch Platform' to confirm.
 - On Scenes in Build add: startup-environment, design-environment and safety-environment 

  <img src="vr-unity/readme/unity-build-setting.png" width="600" />

---

| **Platform** | **Device** | **Requirements**                            | **Commands**                                                                                                                                          |
| ------------ | ---------- | ------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| Windows      | Meta Quest | Unity 2022.3 or higher, Arduino             | `git clone https://github.com/user/repo.git`<br>`cd project-xr`<br>`open MainScene.unity`<br>`Build and Run`                                          |
| Android      | Phone      | Android 19 or higher, ARCore 1.18 or higher | `git clone https://github.com/user/repo.git`<br>`cd solar-system-xr`<br>`open SolarSystemXR.unity`<br>`switch platform to Android`<br>`build and run` |

You also need to install the following dependencies or libraries for your project:

- A Unity plugin for building VR and AR experiences

---

## Usage

To use SolarXR and interact with its features, follow the guidelines below:

1. The game is not stationary and uses hand tracking.
2. Open SolarXR application on your VR headset.
3. Once in the application, you will see a house and panels, start the expirience by pressing buttons on the panels and adjusting parameters for your needs.

## Configuration

...

---

## References

3D Assets:

- https://assetstore.unity.com/packages/3d/props/level-design-modular-starter-pack-288972
- https://assetstore.unity.com/packages/3d/props/industrial/high-quality-solar-panel-175231

---

## Contributors

Evgeniia Dolgikh  
evdo4579@student.su.se  
[Linkedin](https://www.linkedin.com/in/evgeniiadolgikh/)

Fatereh Tondro 
fato3435@student.su.se  
[Linkedin](https://www.linkedin.com/in/fatereh-tondro/)

Ernesto Galarza  
erga4586@student.su.se  
[Linkedin](https://www.linkedin.com/in/ernestoagc/)  
