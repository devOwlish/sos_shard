using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class ShardThrasher : DiamondMace
	{
		public override int LabelNumber{ get{ return 1072918; } } // Shard Thrasher

		[Constructable]
		public ShardThrasher()
		{
			Hue = 0x4F2;
			Name = "Shard Thrasher";

			WeaponAttributes.HitPhysicalArea = 30;
			Attributes.BonusStam = 8;
			Attributes.AttackChance = 10;
			Attributes.WeaponSpeed = 35;
			Attributes.WeaponDamage = 40;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public ShardThrasher( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_ShardThrasher(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}