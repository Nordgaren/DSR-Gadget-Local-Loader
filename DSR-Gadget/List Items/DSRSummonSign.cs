﻿using System;
using System.Globalization;
using PropertyHook;

namespace DSR_Gadget
{
    class DSRSummonSign
    {
        private PHPointer SummonSignPtr;


        public int SummonType
        {
            get => SummonSignPtr.ReadInt32((int)DSROffsets.FrpgNetSosDbItem.SummonType);
            set => SummonSignPtr.WriteInt32((int)DSROffsets.FrpgNetSosDbItem.SummonType, value);
        }

        public int SoulLevel
        {
            get => SummonSignPtr.ReadInt32((int)DSROffsets.FrpgNetSosDbItem.SoulLevel);
        }

        public string Name
        {
            get => SummonSignPtr.ReadString((int)DSROffsets.FrpgNetSosDbItem.Name, System.Text.Encoding.Unicode, 32);
        }

        public string SteamID64Hex
        {
            get => SummonSignPtr.ReadString((int)DSROffsets.FrpgNetSosDbItem.SteamID, System.Text.Encoding.ASCII, 16);
        }

        public long SteamID64
        {
            get
            {
                long steamID64;
                long.TryParse(SteamID64Hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out steamID64);
                return steamID64;
            }
        }

        public float PosX
        {
            get => SummonSignPtr.ReadSingle((int)DSROffsets.FrpgNetSosDbItem.PosX);
            set => SummonSignPtr.WriteSingle((int)DSROffsets.FrpgNetSosDbItem.PosX, value);
        }

        public float PosY
        {
            get => SummonSignPtr.ReadSingle((int)DSROffsets.FrpgNetSosDbItem.PosY);
            set => SummonSignPtr.WriteSingle((int)DSROffsets.FrpgNetSosDbItem.PosY, value);
        }

        public float PosZ
        {
            get => SummonSignPtr.ReadSingle((int)DSROffsets.FrpgNetSosDbItem.PosZ);
            set => SummonSignPtr.WriteSingle((int)DSROffsets.FrpgNetSosDbItem.PosZ, value);
        }

        public float PosAngle
        {
            get => SummonSignPtr.ReadSingle((int)DSROffsets.FrpgNetSosDbItem.PosAngle);
            set => SummonSignPtr.WriteSingle((int)DSROffsets.FrpgNetSosDbItem.PosAngle, value);
        }

        public DSRPlayer.Position GetPosition()
        {
            return new DSRPlayer.Position(PosX, PosY, PosZ, PosAngle);
        }



        public override string ToString()
        {
            return Name + " (" + SteamID64.ToString() + ")";
        }

        public DSRSummonSign(PHPointer summonSignPtr, DSRHook dsrHook)
        {
            SummonSignPtr = summonSignPtr;
        }
    }
}
