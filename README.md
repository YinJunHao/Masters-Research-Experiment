# Video See Through AR Experiment

This experiment is created by YIN JUN HAO, yinjunhao94@gmail.com

Each branch contains a different application and function. Do not combine the branches together!

Before getting started download the files from the necessary branches first. At the very core, the server.py file and an application is needed.

**Steps to get the experiment application started in UNITY**

Server - This step is only needed if you are connecting the galvanic sensors. The default setting is without the server 

1. Download the server.py in the server folder
2. The preferred editor is pycharm
3. The python version used is 3.6, this is the optimum version to used. Dont worry if you have other version of python installed, just set them in your editor
4. Download the required modules as stated in server.py
5. Have a minimum understanding of tcp connection first before starting on this application
6. Have your galvanic skin response sensor ready.
7. Connect the galvanic skin response sensor and turn on the NeulogAPI. https://neulog.com/software/
8. Instructions on acivating the NeulogAPI can be found here. https://neulog.com/wp-content/uploads/2014/06/NeuLog-API-version-7.pdf
9. Change the parameters in server.py 
10. Run server.py
11. The controls of navigating server.py is as shown:
    a. Choose type of device (1 = Tablet, 2 = Tablet AR, 3= HMD AR)
    b. Press "S" to start the tcp connection
    c. Once application and experiment is completed, press "esc". DO NOT PRESS STOP AS THIS WILL RESULT IN THE DATA NOT BEING WRITTEN

Tablet/AR Application in UNITY - Steps 10 to 14 is only needed if you have the server for the galvanic sensor on

This steps are required if the appication is to be run in UNITY
1. Download unity 2018.4.28f1 with vuforia AR and android built support from unity hub. https://unity3d.com/get-unity/download
2. If you have other unity versions, dont be scared cause nothing will be overwritten, a copy of unity 2018 will be there instead
3. Turn on unity
4. A basic understanding of the terms used in unity is needed if not head to https://unity.com/learn/get-started to learn the basics first
5. A baisc understanding of vuforia and how it works is needed if not head to https://www.youtube.com/watch?v=MtiUx_szKbI&t=3s to learn
6. Ensure you are in the main scene, if not go to assests folder in the bottom left of the screen and search for scenes folder
7. Ensure a webcam is connected
8. Ensure you have the stones picture with you https://developer.vuforia.com/sites/default/files/sample-apps/targets/imagetargets_targets.pdf
9. For the AR application, to toggle between glasses and full screen go to AR camera -> vuforia configuration -> viewer type
10. Go to "start" script. Ensure the IP address in line 49 is the same as the ip address as stated in server.py
11. Go to "CreateCSV" script. When using Unity, ensure line 88 is uncommented and line 90 is commented. Comment line 90 back when building to an andriod app
12. Ensure server.py is running
13. Run the unity app by clicking play
14. Wait for tcp connection from server.py 
