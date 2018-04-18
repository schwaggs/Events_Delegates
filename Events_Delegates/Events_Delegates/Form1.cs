using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events_Delegates
{
    public partial class Form1 : Form
    {
        private CustomEventListeners.char16_u count { get; set; }

        public Form1()
        {
            InitializeComponent();

            // Create the custom event listener object
            //count = new CustomEventListeners.Generic(0, typeof(int)); 
            //count = new CustomEventListeners.bool8_u(false);
            count = new CustomEventListeners.char16_u('n');

            // Set the event listener for this object
            count.Element_Changed_Event += Counter_Changed;
        }

        // Called whenever the element is changed i.e. The integer is incremented or decremented.
        private void Counter_Changed(object sender, EventArgs e)
        {
            //textBox1.Text = count.ToInt()).ToString();
            if(count.Element == 'y' || count.Element == 'Y')
            {
                textBox1.Text = "100";
            }

            else if(count.Element == 'n' || count.Element == 'N')
            {
                textBox1.Text = "0";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            //count.Element = 0;
            //count.Element = false;
            count.Element = 'n';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (count.ToInt() == 10)
            //{
            //    count.Element = 0;
            //}

            //else
            //{
            //    int temp = count.ToInt();
            //    temp += 1;
            //    count.Element = temp;
            //}

            //if(!count.Element)
            //{
            //    count.Element = true;
            //}

            count.Element = 'y';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (count.ToInt() == 0)
            //{
            //    count.Element = 10;
            //}

            //else
            //{
            //    int temp = count.ToInt();
            //    temp -= 1;
            //    count.Element = temp;
            //}

            //if(count.Element)
            //{
            //    count.Element = false;
            //}

            count.Element = 'n';
        }
    }

    public static class CustomEventListeners
    {
        #region Generic

        public class Generic
        {
            private object _Element { get; set; }
            private object Lock { get; set; }
            private Type Element_Type { get; set; }

            public Generic(object Default_Element, Type _Element_Type)
            {
                _Element = Default_Element;
                Element_Type = _Element_Type;
                Lock = new object();
            }

            public object Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = value;
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;

            #region Conversion Methods

            public Int16 ToInt16()
            {
                return Convert.ToInt16(_Element);
            }

            public Int32 ToInt32()
            {
                return ToInt();
            }

            public Int64 ToInt64()
            {
                return Convert.ToInt64(_Element);
            }

            public int ToInt()
            {
                return Convert.ToInt32(_Element);
            }

            public char ToChar()
            {
                return Convert.ToChar(_Element);
            }

            public string ToString()
            {
                return Convert.ToString(_Element);
            }

            public float ToFloat()
            {
                return (float)_Element;
            }

            public double ToDouble()
            {
                return Convert.ToDouble(_Element);
            }

            public bool ToBool()
            {
                return Convert.ToBoolean(_Element);
            }

            public UInt16 ToUint16()
            {
                return Convert.ToUInt16(_Element);
            }

            public UInt32 ToUint32()
            {
                return Convert.ToUInt32(_Element);
            }

            public UInt64 ToUint64()
            {
                return Convert.ToUInt64(_Element);
            }

            public decimal ToDecimal()
            {
                return Convert.ToDecimal(_Element);
            }

            #endregion Conversion Methods
        }

        #endregion Generic

        #region int8_s byte_s

        public class int8_s
        {
            private sbyte _Element { get; set; }
            private object Lock { get; set; }

            public int8_s(sbyte Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public sbyte Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToSByte(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int8_s byte_s

        #region int8_u byte_u

        public class int8_u
        {
            private byte _Element { get; set; }
            private object Lock { get; set; }

            public int8_u(byte Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public byte Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToByte(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int8_u byte_u

        #region int16_s short_s

        public class int16_s
        {
            private Int16 _Element { get; set; }
            private object Lock { get; set; }

            public int16_s(Int16 Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public Int16 Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToInt16(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int16_s short_s

        #region int16_u short_u

        public class int16_u
        {
            private UInt16 _Element { get; set; }
            private object Lock { get; set; }

            public int16_u(UInt16 Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public UInt16 Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToUInt16(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int16_u short_u

        #region int32_s int_s

        public class int32_s
        {
            private Int32 _Element { get; set; }
            private object Lock { get; set; }

            public int32_s(Int32 Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public Int32 Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToInt32(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int32_s, int_s

        #region int32_u, int_u

        public class int32_u
        {
            private UInt32 _Element { get; set; }
            private object Lock { get; set; }

            public int32_u(UInt32 Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public UInt32 Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToUInt32(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int32_u, int_u

        #region int64_s long_s

        public class int64_s
        {
            private Int64 _Element { get; set; }
            private object Lock { get; set; }

            public int64_s(Int64 Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public Int64 Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToInt64(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int64_s long_s

        #region int64_u, long_u

        public class int64_u
        {
            private UInt64 _Element { get; set; }
            private object Lock { get; set; }

            public int64_u(UInt64 Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public UInt64 Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToUInt64(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion int64_u, long_u

        #region float32_su

        public class float32_su
        {
            private float _Element { get; set; }
            private object Lock { get; set; }

            public float32_su(float Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public float Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = (float)value;
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion float32_su

        #region double64_su

        public class double64_su
        {
            private double _Element { get; set; }
            private object Lock { get; set; }

            public double64_su(double Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public double Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToDouble(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion double64_su

        #region char16_u

        public class char16_u
        {
            private char _Element { get; set; }
            private object Lock { get; set; }

            public char16_u(char Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public char Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToChar(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion char16_u

        #region bool8_u

        public class bool8_u
        {
            private bool _Element { get; set; }
            private object Lock { get; set; }

            public bool8_u(bool Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public bool Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToBoolean(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion bool8_u

        #region string_u

        public class string_u
        {
            private string _Element { get; set; }
            private object Lock { get; set; }

            public string_u(string Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public string Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToString(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion string_u

        #region decimal128_su

        public class decimal128_su
        {
            private decimal _Element { get; set; }
            private object Lock { get; set; }

            public decimal128_su(decimal Default_Element)
            {
                _Element = Default_Element;
                Lock = new object();
            }

            public decimal Element
            {
                get
                {
                    return _Element;
                }

                set
                {
                    lock (Lock)
                    {
                        _Element = Convert.ToDecimal(value);
                        OnElementChanged(EventArgs.Empty);
                    }
                }
            }

            protected virtual void OnElementChanged(EventArgs e)
            {
                EventHandler handler = Element_Changed_Event;
                handler(this, e);
            }

            public event EventHandler Element_Changed_Event;
        }

        #endregion decimal 128_su
    }
}