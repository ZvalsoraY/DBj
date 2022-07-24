using Interfaces;

namespace JKX
{
    public partial class Form1 : Form
    {
        private ICounterBL _counterBL;
        private IRateBL _rateBL;
        private IReadingBL _readingBL;
        private IServiceBL _serviceBL;
        public Form1(ICounterBL counterBL, IRateBL rateBL, IReadingBL readingBL, IServiceBL serviceBL)
        {
            _counterBL = counterBL;
            _rateBL = rateBL;
            _readingBL = readingBL;
            _serviceBL = serviceBL;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvServices.DataSource = _serviceBL.GetAll();
            dgvRates.DataSource = _rateBL.GetAll();
            dgvCounters.DataSource = _counterBL.GetAll();
            dgvReadings.DataSource = _readingBL.GetAll();
        }
    }
}