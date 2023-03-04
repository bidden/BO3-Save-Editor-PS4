using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BO3_Save_Editor
{
    public partial class Form1 : Form
    {
        public string selected_file = string.Empty;
        public int selected_gumpack = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void firstTab_Click(object sender, EventArgs e)
        {
            firstTab.CustomBorderColor = System.Drawing.Color.Red;
            secondTab.CustomBorderColor = System.Drawing.Color.Transparent;
            thirdTab.CustomBorderColor = System.Drawing.Color.Transparent;

            openFileTab.Visible = true;
            weaponsTab.Visible = false;
            gumsTab.Visible = false;
        }

        private void secondTab_Click(object sender, EventArgs e)
        {
            firstTab.CustomBorderColor = System.Drawing.Color.Transparent;
            secondTab.CustomBorderColor = System.Drawing.Color.Red;
            thirdTab.CustomBorderColor = System.Drawing.Color.Transparent;

            openFileTab.Visible = false;
            weaponsTab.Visible = true;
            gumsTab.Visible = false;
        }

        private void thirdTab_Click(object sender, EventArgs e)
        {
            firstTab.CustomBorderColor = System.Drawing.Color.Transparent;
            secondTab.CustomBorderColor = System.Drawing.Color.Transparent;
            thirdTab.CustomBorderColor = System.Drawing.Color.Red;

            openFileTab.Visible = false;
            weaponsTab.Visible = false;
            gumsTab.Visible = true;
        }

        private enum GumByte : byte
        {
            None = 0,
            AlwaysDoneSwiftly = 202,
            ArmsGrace = 205,
            Coagulant = 207,
            InPlainSight = 211,
            StockOption = 214,
            Impatient = 210,
            SwordFlay = 215,
            AnywhereButHere = 203,
            DangerClosest = 208,
            ArmamentalAccomplishment = 204,
            FiringOnAllCylinders = 209,
            ArsenalAccelerator = 206,
            LuckyCrit = 212,
            NowYouSeeMe = 213,
            AlchemicalAntithesis = 201,
            EyeCandy = 196,
            NewtonianNegation = 250,
            ProjectileVomiting = 244,
            ToneDeath = 190
        }

        private void setupCamos()
        {
            camoComboBox.Items.Clear();
            weapComboBox.Items.Clear();
            camoComboBox.DataSource = Enum.GetNames(typeof(Camos));
            weapComboBox.DataSource = Enum.GetNames(typeof(Weapons));
        }

        private void setupZombies()
        {
            choosePack.Items.Clear();
            choosePack.Items.Add("GobbleGum Pack 1");
            choosePack.Items.Add("GobbleGum Pack 2");
            choosePack.Items.Add("GobbleGum Pack 3");
            choosePack.Items.Add("GobbleGum Pack 4");
            choosePack.Items.Add("GobbleGum Pack 5");
            choosePack.Items.Add("GobbleGum Pack 6");
            choosePack.Items.Add("GobbleGum Pack 7");
            choosePack.Items.Add("GobbleGum Pack 8");
            choosePack.Items.Add("GobbleGum Pack 9");
            choosePack.Items.Add("GobbleGum Pack 10");

            gum1.Items.Clear();
            gum2.Items.Clear();
            gum3.Items.Clear();
            gum4.Items.Clear();
            gum5.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(GumByte)))
            {
                gum1.Items.Add(item);
                gum2.Items.Add(item);
                gum3.Items.Add(item);
                gum4.Items.Add(item);
                gum5.Items.Add(item);
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ZM Settings File|*loadouts_zm_offline*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selected_file = dialog.FileName;
                secondTab.Visible = true;
                thirdTab.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setupCamos();
            setupZombies();
        }

        private void choosePack_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_gumpack = choosePack.SelectedIndex;
            packName.Text = "";
            gum1.SelectedIndex = -1;
            gum2.SelectedIndex = -1;
            gum3.SelectedIndex = -1;
            gum4.SelectedIndex = -1;
            gum5.SelectedIndex = -1;
        }

        private void packName_TextChanged(object sender, EventArgs e)
        {
            if (selected_gumpack != -1)
            {
                var file = File.OpenWrite(selected_file);
                var packText = new List<byte>();
                switch (selected_gumpack)
                {
                    case 0:
                        packName.MaxLength = 16;
                        file.Seek(4487, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        } else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 1:
                        packName.MaxLength = 16;
                        file.Seek(4509, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 2:
                        packName.MaxLength = 16;
                        file.Seek(4531, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 3:
                        packName.MaxLength = 16;
                        file.Seek(4553, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 4:
                        packName.MaxLength = 16;
                        file.Seek(4575, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 5:
                        packName.MaxLength = 16;
                        file.Seek(4597, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 6:
                        packName.MaxLength = 16;
                        file.Seek(4619, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 7:
                        packName.MaxLength = 16;
                        file.Seek(4641, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 8:
                        packName.MaxLength = 16;
                        file.Seek(4663, SeekOrigin.Current);
                        if (packName.Text.Length < 16)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 16)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                    case 9:
                        packName.MaxLength = 17;
                        file.Seek(4685, SeekOrigin.Current);
                        if (packName.Text.Length < 17)
                        {
                            packText.Clear();
                            foreach (byte a in Encoding.Default.GetBytes(packName.Text))
                            {

                                packText.Add(a);
                            }
                            packText.Add(0x00);
                            file.Write(packText.ToArray(), 0, packText.Count);
                        }
                        else if (packName.Text.Length == 17)
                        {
                            file.Write(Encoding.Default.GetBytes(packName.Text), 0, packName.Text.Length);
                        }
                        file.Close();
                        break;
                }
            }
        }

        private void gum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected_gumpack != -1)
            {
                var file = File.OpenWrite(selected_file);
                switch (selected_gumpack)
                {
                    case 0:
                        file.Seek(4504, SeekOrigin.Current);
                        break;
                    case 1:
                        file.Seek(4526, SeekOrigin.Current);
                        break;
                    case 2:
                        file.Seek(4548, SeekOrigin.Current);
                        break;
                    case 3:
                        file.Seek(4570, SeekOrigin.Current);
                        break;
                    case 4:
                        file.Seek(4592, SeekOrigin.Current);
                        break;
                    case 5:
                        file.Seek(4614, SeekOrigin.Current);
                        break;
                    case 6:
                        file.Seek(4636, SeekOrigin.Current);
                        break;
                    case 7:
                        file.Seek(4658, SeekOrigin.Current);
                        break;
                    case 8:
                        file.Seek(4680, SeekOrigin.Current);
                        break;
                    case 9:
                        file.Seek(4702, SeekOrigin.Current);
                        break;
                }

                switch (gum1.SelectedIndex)
                {
                    case 0:
                        file.WriteByte((byte)GumByte.None);
                        file.Close();
                        break;
                    case 1:
                        file.WriteByte((byte)GumByte.ToneDeath);
                        file.Close();
                        break;
                    case 2:
                        file.WriteByte((byte)GumByte.EyeCandy);
                        file.Close();
                        break;
                    case 3:
                        file.WriteByte((byte)GumByte.AlchemicalAntithesis);
                        file.Close();
                        break;
                    case 4:
                        file.WriteByte((byte)GumByte.AlwaysDoneSwiftly);
                        file.Close();
                        break;
                    case 5:
                        file.WriteByte((byte)GumByte.AnywhereButHere);
                        file.Close();
                        break;
                    case 6:
                        file.WriteByte((byte)GumByte.ArmamentalAccomplishment);
                        file.Close();
                        break;
                    case 7:
                        file.WriteByte((byte)GumByte.ArmsGrace);
                        file.Close();
                        break;
                    case 8:
                        file.WriteByte((byte)GumByte.ArsenalAccelerator);
                        file.Close();
                        break;
                    case 9:
                        file.WriteByte((byte)GumByte.Coagulant);
                        file.Close();
                        break;
                    case 10:
                        file.WriteByte((byte)GumByte.DangerClosest);
                        file.Close();
                        break;
                    case 11:
                        file.WriteByte((byte)GumByte.FiringOnAllCylinders);
                        file.Close();
                        break;
                    case 12:
                        file.WriteByte((byte)GumByte.Impatient);
                        file.Close();
                        break;
                    case 13:
                        file.WriteByte((byte)GumByte.InPlainSight);
                        file.Close();
                        break;
                    case 14:
                        file.WriteByte((byte)GumByte.LuckyCrit);
                        file.Close();
                        break;
                    case 15:
                        file.WriteByte((byte)GumByte.NowYouSeeMe);
                        file.Close();
                        break;
                    case 16:
                        file.WriteByte((byte)GumByte.StockOption);
                        file.Close();
                        break;
                    case 17:
                        file.WriteByte((byte)GumByte.SwordFlay);
                        file.Close();
                        break;
                    case 18:
                        file.WriteByte((byte)GumByte.ProjectileVomiting);
                        file.Close();
                        break;
                    case 19:
                        file.WriteByte((byte)GumByte.NewtonianNegation);
                        file.Close();
                        break;
                }
            }
        }

        private void gum2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected_gumpack != -1)
            {
                var file = File.OpenWrite(selected_file);
                switch (selected_gumpack)
                {
                    case 0:
                        file.Seek(4505, SeekOrigin.Current);
                        break;
                    case 1:
                        file.Seek(4527, SeekOrigin.Current);
                        break;
                    case 2:
                        file.Seek(4549, SeekOrigin.Current);
                        break;
                    case 3:
                        file.Seek(4571, SeekOrigin.Current);
                        break;
                    case 4:
                        file.Seek(4593, SeekOrigin.Current);
                        break;
                    case 5:
                        file.Seek(4615, SeekOrigin.Current);
                        break;
                    case 6:
                        file.Seek(4637, SeekOrigin.Current);
                        break;
                    case 7:
                        file.Seek(4659, SeekOrigin.Current);
                        break;
                    case 8:
                        file.Seek(4681, SeekOrigin.Current);
                        break;
                    case 9:
                        file.Seek(4703, SeekOrigin.Current);
                        break;
                }

                switch (gum2.SelectedIndex)
                {
                    case 0:
                        file.WriteByte((byte)GumByte.None);
                        file.Close();
                        break;
                    case 1:
                        file.WriteByte((byte)GumByte.ToneDeath);
                        file.Close();
                        break;
                    case 2:
                        file.WriteByte((byte)GumByte.EyeCandy);
                        file.Close();
                        break;
                    case 3:
                        file.WriteByte((byte)GumByte.AlchemicalAntithesis);
                        file.Close();
                        break;
                    case 4:
                        file.WriteByte((byte)GumByte.AlwaysDoneSwiftly);
                        file.Close();
                        break;
                    case 5:
                        file.WriteByte((byte)GumByte.AnywhereButHere);
                        file.Close();
                        break;
                    case 6:
                        file.WriteByte((byte)GumByte.ArmamentalAccomplishment);
                        file.Close();
                        break;
                    case 7:
                        file.WriteByte((byte)GumByte.ArmsGrace);
                        file.Close();
                        break;
                    case 8:
                        file.WriteByte((byte)GumByte.ArsenalAccelerator);
                        file.Close();
                        break;
                    case 9:
                        file.WriteByte((byte)GumByte.Coagulant);
                        file.Close();
                        break;
                    case 10:
                        file.WriteByte((byte)GumByte.DangerClosest);
                        file.Close();
                        break;
                    case 11:
                        file.WriteByte((byte)GumByte.FiringOnAllCylinders);
                        file.Close();
                        break;
                    case 12:
                        file.WriteByte((byte)GumByte.Impatient);
                        file.Close();
                        break;
                    case 13:
                        file.WriteByte((byte)GumByte.InPlainSight);
                        file.Close();
                        break;
                    case 14:
                        file.WriteByte((byte)GumByte.LuckyCrit);
                        file.Close();
                        break;
                    case 15:
                        file.WriteByte((byte)GumByte.NowYouSeeMe);
                        file.Close();
                        break;
                    case 16:
                        file.WriteByte((byte)GumByte.StockOption);
                        file.Close();
                        break;
                    case 17:
                        file.WriteByte((byte)GumByte.SwordFlay);
                        file.Close();
                        break;
                    case 18:
                        file.WriteByte((byte)GumByte.ProjectileVomiting);
                        file.Close();
                        break;
                    case 19:
                        file.WriteByte((byte)GumByte.NewtonianNegation);
                        file.Close();
                        break;
                }
            }
        }

        private void gum3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected_gumpack != -1)
            {
                var file = File.OpenWrite(selected_file);
                switch (selected_gumpack)
                {
                    case 0:
                        file.Seek(4506, SeekOrigin.Current);
                        break;
                    case 1:
                        file.Seek(4528, SeekOrigin.Current);
                        break;
                    case 2:
                        file.Seek(4550, SeekOrigin.Current);
                        break;
                    case 3:
                        file.Seek(4572, SeekOrigin.Current);
                        break;
                    case 4:
                        file.Seek(4594, SeekOrigin.Current);
                        break;
                    case 5:
                        file.Seek(4616, SeekOrigin.Current);
                        break;
                    case 6:
                        file.Seek(4638, SeekOrigin.Current);
                        break;
                    case 7:
                        file.Seek(4660, SeekOrigin.Current);
                        break;
                    case 8:
                        file.Seek(4682, SeekOrigin.Current);
                        break;
                    case 9:
                        file.Seek(4704, SeekOrigin.Current);
                        break;
                }

                switch (gum3.SelectedIndex)
                {
                    case 0:
                        file.WriteByte((byte)GumByte.None);
                        file.Close();
                        break;
                    case 1:
                        file.WriteByte((byte)GumByte.ToneDeath);
                        file.Close();
                        break;
                    case 2:
                        file.WriteByte((byte)GumByte.EyeCandy);
                        file.Close();
                        break;
                    case 3:
                        file.WriteByte((byte)GumByte.AlchemicalAntithesis);
                        file.Close();
                        break;
                    case 4:
                        file.WriteByte((byte)GumByte.AlwaysDoneSwiftly);
                        file.Close();
                        break;
                    case 5:
                        file.WriteByte((byte)GumByte.AnywhereButHere);
                        file.Close();
                        break;
                    case 6:
                        file.WriteByte((byte)GumByte.ArmamentalAccomplishment);
                        file.Close();
                        break;
                    case 7:
                        file.WriteByte((byte)GumByte.ArmsGrace);
                        file.Close();
                        break;
                    case 8:
                        file.WriteByte((byte)GumByte.ArsenalAccelerator);
                        file.Close();
                        break;
                    case 9:
                        file.WriteByte((byte)GumByte.Coagulant);
                        file.Close();
                        break;
                    case 10:
                        file.WriteByte((byte)GumByte.DangerClosest);
                        file.Close();
                        break;
                    case 11:
                        file.WriteByte((byte)GumByte.FiringOnAllCylinders);
                        file.Close();
                        break;
                    case 12:
                        file.WriteByte((byte)GumByte.Impatient);
                        file.Close();
                        break;
                    case 13:
                        file.WriteByte((byte)GumByte.InPlainSight);
                        file.Close();
                        break;
                    case 14:
                        file.WriteByte((byte)GumByte.LuckyCrit);
                        file.Close();
                        break;
                    case 15:
                        file.WriteByte((byte)GumByte.NowYouSeeMe);
                        file.Close();
                        break;
                    case 16:
                        file.WriteByte((byte)GumByte.StockOption);
                        file.Close();
                        break;
                    case 17:
                        file.WriteByte((byte)GumByte.SwordFlay);
                        file.Close();
                        break;
                    case 18:
                        file.WriteByte((byte)GumByte.ProjectileVomiting);
                        file.Close();
                        break;
                    case 19:
                        file.WriteByte((byte)GumByte.NewtonianNegation);
                        file.Close();
                        break;
                }
            }
        }

        private void gum4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected_gumpack != -1)
            {
                var file = File.OpenWrite(selected_file);
                switch (selected_gumpack)
                {
                    case 0:
                        file.Seek(4507, SeekOrigin.Current);
                        break;
                    case 1:
                        file.Seek(4529, SeekOrigin.Current);
                        break;
                    case 2:
                        file.Seek(4551, SeekOrigin.Current);
                        break;
                    case 3:
                        file.Seek(4573, SeekOrigin.Current);
                        break;
                    case 4:
                        file.Seek(4595, SeekOrigin.Current);
                        break;
                    case 5:
                        file.Seek(4617, SeekOrigin.Current);
                        break;
                    case 6:
                        file.Seek(4639, SeekOrigin.Current);
                        break;
                    case 7:
                        file.Seek(4661, SeekOrigin.Current);
                        break;
                    case 8:
                        file.Seek(4683, SeekOrigin.Current);
                        break;
                    case 9:
                        file.Seek(4705, SeekOrigin.Current);
                        break;
                }

                switch (gum4.SelectedIndex)
                {
                    case 0:
                        file.WriteByte((byte)GumByte.None);
                        file.Close();
                        break;
                    case 1:
                        file.WriteByte((byte)GumByte.ToneDeath);
                        file.Close();
                        break;
                    case 2:
                        file.WriteByte((byte)GumByte.EyeCandy);
                        file.Close();
                        break;
                    case 3:
                        file.WriteByte((byte)GumByte.AlchemicalAntithesis);
                        file.Close();
                        break;
                    case 4:
                        file.WriteByte((byte)GumByte.AlwaysDoneSwiftly);
                        file.Close();
                        break;
                    case 5:
                        file.WriteByte((byte)GumByte.AnywhereButHere);
                        file.Close();
                        break;
                    case 6:
                        file.WriteByte((byte)GumByte.ArmamentalAccomplishment);
                        file.Close();
                        break;
                    case 7:
                        file.WriteByte((byte)GumByte.ArmsGrace);
                        file.Close();
                        break;
                    case 8:
                        file.WriteByte((byte)GumByte.ArsenalAccelerator);
                        file.Close();
                        break;
                    case 9:
                        file.WriteByte((byte)GumByte.Coagulant);
                        file.Close();
                        break;
                    case 10:
                        file.WriteByte((byte)GumByte.DangerClosest);
                        file.Close();
                        break;
                    case 11:
                        file.WriteByte((byte)GumByte.FiringOnAllCylinders);
                        file.Close();
                        break;
                    case 12:
                        file.WriteByte((byte)GumByte.Impatient);
                        file.Close();
                        break;
                    case 13:
                        file.WriteByte((byte)GumByte.InPlainSight);
                        file.Close();
                        break;
                    case 14:
                        file.WriteByte((byte)GumByte.LuckyCrit);
                        file.Close();
                        break;
                    case 15:
                        file.WriteByte((byte)GumByte.NowYouSeeMe);
                        file.Close();
                        break;
                    case 16:
                        file.WriteByte((byte)GumByte.StockOption);
                        file.Close();
                        break;
                    case 17:
                        file.WriteByte((byte)GumByte.SwordFlay);
                        file.Close();
                        break;
                    case 18:
                        file.WriteByte((byte)GumByte.ProjectileVomiting);
                        file.Close();
                        break;
                    case 19:
                        file.WriteByte((byte)GumByte.NewtonianNegation);
                        file.Close();
                        break;
                }
            }
        }

        private void gum5_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (selected_gumpack != -1)
            {
                var file = File.OpenWrite(selected_file);
                switch (selected_gumpack)
                {
                    case 0:
                        file.Seek(4508, SeekOrigin.Current);
                        break;
                    case 1:
                        file.Seek(4530, SeekOrigin.Current);
                        break;
                    case 2:
                        file.Seek(4552, SeekOrigin.Current);
                        break;
                    case 3:
                        file.Seek(4574, SeekOrigin.Current);
                        break;
                    case 4:
                        file.Seek(4596, SeekOrigin.Current);
                        break;
                    case 5:
                        file.Seek(4618, SeekOrigin.Current);
                        break;
                    case 6:
                        file.Seek(4640, SeekOrigin.Current);
                        break;
                    case 7:
                        file.Seek(4662, SeekOrigin.Current);
                        break;
                    case 8:
                        file.Seek(4684, SeekOrigin.Current);
                        break;
                    case 9:
                        file.Seek(4706, SeekOrigin.Current);
                        break;
                }

                switch (gum4.SelectedIndex)
                {
                    case 0:
                        file.WriteByte((byte)GumByte.None);
                        file.Close();
                        break;
                    case 1:
                        file.WriteByte((byte)GumByte.ToneDeath);
                        file.Close();
                        break;
                    case 2:
                        file.WriteByte((byte)GumByte.EyeCandy);
                        file.Close();
                        break;
                    case 3:
                        file.WriteByte((byte)GumByte.AlchemicalAntithesis);
                        file.Close();
                        break;
                    case 4:
                        file.WriteByte((byte)GumByte.AlwaysDoneSwiftly);
                        file.Close();
                        break;
                    case 5:
                        file.WriteByte((byte)GumByte.AnywhereButHere);
                        file.Close();
                        break;
                    case 6:
                        file.WriteByte((byte)GumByte.ArmamentalAccomplishment);
                        file.Close();
                        break;
                    case 7:
                        file.WriteByte((byte)GumByte.ArmsGrace);
                        file.Close();
                        break;
                    case 8:
                        file.WriteByte((byte)GumByte.ArsenalAccelerator);
                        file.Close();
                        break;
                    case 9:
                        file.WriteByte((byte)GumByte.Coagulant);
                        file.Close();
                        break;
                    case 10:
                        file.WriteByte((byte)GumByte.DangerClosest);
                        file.Close();
                        break;
                    case 11:
                        file.WriteByte((byte)GumByte.FiringOnAllCylinders);
                        file.Close();
                        break;
                    case 12:
                        file.WriteByte((byte)GumByte.Impatient);
                        file.Close();
                        break;
                    case 13:
                        file.WriteByte((byte)GumByte.InPlainSight);
                        file.Close();
                        break;
                    case 14:
                        file.WriteByte((byte)GumByte.LuckyCrit);
                        file.Close();
                        break;
                    case 15:
                        file.WriteByte((byte)GumByte.NowYouSeeMe);
                        file.Close();
                        break;
                    case 16:
                        file.WriteByte((byte)GumByte.StockOption);
                        file.Close();
                        break;
                    case 17:
                        file.WriteByte((byte)GumByte.SwordFlay);
                        file.Close();
                        break;
                    case 18:
                        file.WriteByte((byte)GumByte.ProjectileVomiting);
                        file.Close();
                        break;
                    case 19:
                        file.WriteByte((byte)GumByte.NewtonianNegation);
                        file.Close();
                        break;
                }
            }
        }

        private enum Camos : byte
        {
            None = 0,
            JungleTech = 1,
            Ash = 2,
            Flectarn = 3,
            HeatStroke = 4,
            SnowJob = 5,
            Dante = 6,
            Integer = 7,
            SixSpeed = 8,
            Policia = 9,
            Ardent = 10,
            Burnt = 11,
            Bliss = 12,
            Battle = 13,
            Chameleon = 14,
            Gold = 15,
            Diamond = 16,
            DarkMatter = 17,
            Arctic = 18,
            Jungle = 19,
            Huntsman = 20,
            Woodlums = 21,
            Contagious = 22,
            Fear = 23,
            WMD = 24,
            RedHex = 25,
            ShadowsOfEvil = 26,
            BlackOps3 = 27,
            Weaponized115 = 28,
            Cyborg = 29,
            TrueVet = 30,
            TakeOut = 33,
            Nuk3town = 35,
            Transgression = 36,
            Storm = 38,
            Wartorn = 39,
            Prestige = 40,
            TheGiant = 42,
            Ice = 43,
            Dust = 44,
            JungleParty = 46,
            Contrast = 47,
            Verde = 48,
            Firebrand = 49,
            Field = 50,
            Stealth = 51,
            Light = 52,
            Spark = 53,
            Timber = 54,
            Inferno = 55,
            Hallucination = 56,
            Pixel = 57,
            Royal = 58,
            Infrared = 59,
            Heat = 60,
            Violet = 61,
            Halcyon = 62,
            Gem = 63,
            Monochrome = 64,
            Sunshine = 65,
            Swindler = 66,
            CODEWarriors = 67,
            Intensity = 68,
            Energeon = 74,
            DerEisendracheYellow = 75,
            DerEisendracheRed = 76,
            DerEisendracheBlue = 77,
            DerEisendracheGreen = 78,
            DerEisendrachePurple = 79,
            DerEisendracheWhite = 80,
            ZetsubouNoShima = 81,
            BloodyValentine = 82,
            Haptic = 83,
            GorodKroviOrange = 84,
            GorodKroviBlue = 85,
            GorodKroviGreen = 86,
            GorodKroviRed = 87,
            GorodKroviPurple = 88,
            CODXP = 89,
            Champions = 90,
            Excellence = 93,
            MindFreak = 95,
            Nv = 96,
            OrbitGG = 97,
            TaintedMinds = 98,
            EpsiloneSports = 99,
            TeamInfused = 103,
            TeamLDLC = 104,
            Millenium = 105,
            Splyce = 106,
            Supremacy = 107,
            Cloud9 = 109,
            eLevate = 111,
            TeamEnVy = 112,
            FaZeClan = 113,
            OpTicGaming = 116,
            RiseNation = 117,
            Underworld = 119,
            RevelationsBlueAndRed = 121,
            RevelationsGreen = 122,
            RevelationsBlue = 123,
            RevelationsElectricBlue = 124,
            RevelationsRed = 125,
            Lucid = 126,
            LuckOfTheIrish = 131,
            BlackOps1 = 132,
            Origins = 133,
            CherryFizz = 134,
            Empire = 135,
            Permafrost = 136,
            Hive = 137
        }

        private enum Weapons: long
        {
            Vesper = 0x1294,
            VMP = 0x12F8,
            Kuda = 0x135C,
            Pharo = 0x12C6,
            Weevil = 0x132A,
            ICR1 = 0x138E,
            KN44 = 0x13C0,
            M8A7 = 0x1424,
            Sheiva = 0x1488,
            HVK30 = 0x1456,
            ManOWar = 0x14BA,
            KRM262 = 0x13F2,
            Argus = 0x1550,
            _205Brecci = 0x14EC,
            Haymaker12 = 0x151E,
            BRM = 0x15E6,
            Dingo = 0x1618,
            _48Dredge = 0x15B4,
            Gorgon = 0x1582,
            Locus = 0x16AE,
            Drakon = 0x167C,
            SVG100 = 0x164A,
            BowieKnife = 0x16E0,
            RK5 = 0x1744,
            LCAR9 = 0x1712,
            XM53 = 0x1776
        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            long selected_weapon = (long)Enum.Parse(typeof(Weapons), weapComboBox.SelectedValue.ToString());
            byte selected_camo = (byte)Enum.Parse(typeof(Camos), camoComboBox.SelectedValue.ToString());

            var file = File.OpenWrite(selected_file);
            file.Seek(selected_weapon, SeekOrigin.Begin);
            file.WriteByte(selected_camo);
            file.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bidden");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCwZlt_Gbf0ey6Z-4hfUqMAA");
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bidden");
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bidden");
        }
    }
}
