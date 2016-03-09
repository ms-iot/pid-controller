# PID Controller
A Universal Windows Runtime Component that implements a very simple [proportional-integral-derivative controller](https://en.wikipedia.org/wiki/PID_controller).

## Installation
### Step 1: Create a new project!

1. In Visual Studio select *File -> New -> Project*

2. Select your language of choice. The PID Controller is a Universal Windows Runtime Component, meaning it is compatable with C++, C#, or JavaScript.

3. Select the "Windows" option under the language you selected and choose "Blank App (Universal Windows)".

### Step 2: Add the PidController project to your solution

1. Clone the [PID Controller repository](https://github.com/ms-iot/pid-controller.git) or download the [zip file](https://github.com/ms-iot/pid-controller/archive/master.zip).

2. Right-click on your solution in the Solution Explorer and select *Add -> Existing Project*

3. Navigate to your local copy of the PID Controller repository and select **PidController.csproj**

6. Right-click on **References** in your main project within the solution. Select *Add Reference*

7. Under the "Projects" tab, select **PidController**

8. Rebuild your solution by selecting *Build -> Rebuild All*


## Example
For an example of this code being used to control motor RPM see our [Closed-Loop Control Demo](https://github.com/sidwarkd/pid-control-system).

## Constructor
```cs
PidController controller = new PidController(float GainProportional, float GainIntegral, float GainDerivative, float OutputMax, float OutputMin);
```

  * ```GainProportional``` - The proportional gain in the feedback loop
  * ```GainIntegral``` - The integral gain in the feedback loop
  * ```GainDerivative``` - The derivative gain in the feedback loop
  * ```OutputMax``` - The maximum value the ```ControlVariable``` property can return
  * ```OutputMin``` - The minimum value the ```ControlVariable``` property can return

## Properties
| Property            | Type        | Access  | Description                                                     |
|---------------------|-------------|---------|-----------------------------------------------------------------|
| GainProportional    | ```float``` | get/set | The proportional gain in the feedback loop                      |
| GainIntegral        | ```float``` | get/set | The integral gain in the feedback loop                          |
| GainDerivative      | ```float``` | get/set | The derivative gain in the feedback loop                        |
| OutputMax           | ```float``` | get     | The maximum value the ```ControlVariable``` property can return |
| OutputMin           | ```float``` | get     | The minimum value the ```ControlVariable``` property can return |
| IntegralTerm        | ```float``` | get     | Tracks the accumulated error in the control loop                |
| ProcessVariable     | ```float``` | get/set | Current value of the process under control                      |
| ProcessVariableLast | ```float``` | get     | Last stored value of the process under control                  |
| SetPoint            | ```float``` | get/set | The desired value of the process under control                  |
| ControlVariable     | ```float``` | get     | The control variable that drives the process under control      |

## Tuning
There are lots of resources online for learning how to tune a PID controller. For a quick primer see the Wikipedia entry on [manual tuning](https://en.wikipedia.org/wiki/PID_controller#Manual_tuning).
