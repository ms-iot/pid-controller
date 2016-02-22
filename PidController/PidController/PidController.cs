namespace PidController
{
    /// <summary>
    /// A (P)roportional, (I)ntegral, (D)erivative Controller
    /// </summary>
    /// <remarks>
    /// The controller should be able to control any process with a
    /// measureable value, a known ideal value and an input to the
    /// process that will affect the measured value.
    /// </remarks>
    /// <see cref="https://en.wikipedia.org/wiki/PID_controller"/>
    public sealed class PidController
    {
        private float processVariable = 0.0f;

        public PidController(float GainProportional, float GainIntegral, float GainDerivative, float OutputMax, float OutputMin)
        {
            this.GainDerivative = GainDerivative;
            this.GainIntegral = GainIntegral;
            this.GainProportional = GainProportional;
            this.OutputMax = OutputMax;
            this.OutputMin = OutputMin;
        }

        /// <summary>
        /// The controller output
        /// </summary>
        public float ControlVariable
        {
            get
            {
                float error = SetPoint - ProcessVariable;
                IntegralTerm += (GainIntegral * error);
                if (IntegralTerm > OutputMax) IntegralTerm = OutputMax;
                if (IntegralTerm < OutputMin) IntegralTerm = OutputMin;
                float dInput = processVariable - ProcessVariableLast;

                float output = GainProportional * error + IntegralTerm - GainDerivative * dInput;

                if (output > OutputMax) output = OutputMax;
                if (output < OutputMin) output = OutputMin;

                return output;
            }
        }

        /// <summary>
        /// The derivative term is proportional to the rate of
        /// change of the error
        /// </summary>
        public float GainDerivative { get; set; } = 0;

        /// <summary>
        /// The integral term is proportional to both the magnitude
        /// of the error and the duration of the error
        /// </summary>
        public float GainIntegral { get; set; } = 0;

        /// <summary>
        /// The proportional term produces an output value that
        /// is proportional to the current error value
        /// </summary>
        /// <remarks>
        /// Tuning theory and industrial practice indicate that the
        /// proportional term should contribute the bulk of the output change.
        /// </remarks>
        public float GainProportional { get; set; } = 0;

        /// <summary>
        /// Adjustment made by considering the rate of change of the error
        /// </summary>
        /// <remarks>
        /// Returns the inverse of the slope to dampen overshoot
        /// </remarks>
        public float InputDerivative { get { return (ProcessVariableLast - processVariable); } }

        /// <summary>
        /// The max output value the control device can accept.
        /// </summary>
        public float OutputMax { get; private set; } = 0;

        /// <summary>
        /// The minimum ouput value the control device can accept.
        /// </summary>
        public float OutputMin { get; private set; } = 0;

        /// <summary>
        /// Adjustment made by considering the accumulated error over time
        /// </summary>
        /// <remarks>
        /// An alternative formulation of the integral action, is the
        /// proportional-summation-difference used in discrete-time systems
        /// </remarks>
        public float IntegralTerm { get; set; } = 0;


        /// <summary>
        /// The current value
        /// </summary>
        public float ProcessVariable {
            get { return processVariable; }
            set {
                ProcessVariableLast = processVariable;
                processVariable = value;
            }
        }

        /// <summary>
        /// The last reported value (used to calculate the rate of change)
        /// </summary>
        public float ProcessVariableLast { get; private set; } = 0;

        /// <summary>
        /// The desired value
        /// </summary>
        public float SetPoint { get; set; } = 0;
    }
}
