namespace Road.Base.Packets
{
    public class FSM
    {
        private int _adder;
        private int _mulitper;
        private int _state;
        public int count;
        public string name;

        public FSM(int adder, int mulitper, string objname)
        {
            this.name = objname;
            this.count = 0;
            this._adder = adder;
            this._mulitper = mulitper;
            this.UpdateState();
        }

        public int getState()
        {
            return this._state;
        }

        public int getAdder()
        {
            return this._adder;
        }

        public int getMulitper()
        {
            return this._mulitper;
        }

        public void Setup(int adder, int mulitper)
        {
            this._adder = adder;
            this._mulitper = mulitper;
            this.UpdateState();
        }

        public int UpdateState()
        {
            this._state = (~this._state + this._adder) * this._mulitper;
            this._state ^= this._state >> 16;
            ++this.count;
            return this._state;
        }
    }
}
