

namespace UI;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }


    private void button1_Click(object sender, EventArgs e)
    {
        Manager manager = new Manager();
        this.Hide();
        manager.FormClosed += Menu_FormClosed;
        manager.Show();
    }
    private void Menu_FormClosed(object? sender, FormClosedEventArgs e)
    {
        this.Show();
    }

    private void Cashier_Click(object sender, EventArgs e)
    {
        Cashier cashier = new Cashier();
        this.Hide();
        cashier.FormClosed += Menu_FormClosed;
        cashier.Show();
    }
}
