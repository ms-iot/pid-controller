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

        public PidController() : this(1.0f, 0.5f, 0.0f)
        {
        }

        public PidController(float GainProportional) : this(GainProportional, 0.5f, 0.0f)
        {
        }

        public PidController(float GainProportional, float GainIntegral) : this(GainProportional, GainIntegral, 0.0f)
        {
        }

        public PidController(float GainProportional, float GainIntegral, float GainDerivative)
        {
            this.GainDerivative = GainDerivative;
            this.GainIntegral = GainIntegral;
            this.GainProportional = GainProportional;
        }

        /// <summary>
        /// The controller output
        /// </summary>
        public float ControlVariable { get { return ((GainProportional * InputProportional) + (GainIntegral * InputIntegral) + (GainDerivative * InputDerivative)); } }

        /// <summary>
        /// The difference between the current value and the desired value
        /// </summary>
        public float Error { get { return (SetPoint - processVariable); } }

        /// <summary>
        /// The area under the curve created by the oscillation of the PID controller
        /// </summary>
        public float ErrorAccumulated { get; private set; } = 0;

        /// <summary>
        /// The derivative term is proportional to the rate of
        /// change of the error
        /// </summary>
        public float GainDerivative { get; private set; } = 0;

        /// <summary>
        /// The integral term is proportional to both the magnitude
        /// of the error and the duration of the error
        /// </summary>
        public float GainIntegral { get; private set; } = 0;

        /// <summary>
        /// The proportional term produces an output value that
        /// is proportional to the current error value
        /// </summary>
        /// <remarks>
        /// Tuning theory and industrial practice indicate that the
        /// proportional term should contribute the bulk of the output change.
        /// </remarks>
        public float GainProportional { get; private set; } = 0;

        /// <summary>
        /// Adjustment made by considering the rate of change of the error
        /// </summary>
        /// <remarks>
        /// Returns the inverse of the slope to dampen overshoot
        /// </remarks>
        public float InputDerivative { get { return (ProcessVariableLast - processVariable); } }

        /// <summary>
        /// Adjustment made by considering the accumulated error over time
        /// </summary>
        /// <remarks>
        /// An alternative formulation of the integral action, is the
        /// proportional-summation-difference used in discrete-time systems
        /// </remarks>
        public float InputIntegral
        {
            get
            {
                // Test for reset conditions for accumulated error
                if (0 == Error) { ErrorAccumulated = 0.0f; }
                if ((0 > Error && 0 < ErrorAccumulated) || (0 < Error && 0 > ErrorAccumulated)) { ErrorAccumulated = 0.0f; }

                return (ErrorAccumulated += Error);
            }
        }

        /// <summary>
        /// Adjustment made in proportion to the existing error
        /// </summary>
        public float InputProportional { get { return Error * GainProportional; } }

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
