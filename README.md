# PID Controller
A Universal Windows Runtime Component that implements a very simple [proportional-integral-derivative controller](https://en.wikipedia.org/wiki/PID_controller).

## Example
For an example of this code being used to control motor RPM see our [Closed-Loop Control Demo]().

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
