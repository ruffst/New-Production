$BlockIds = @(




  'LargeGridBeamBlockTJunction'
  'SmallGridBeamBlock'
  'SmallGridBeamBlockSlope'
  'SmallGridBeamBlockRound'
  'SmallGridBeamBlockSlope2x1Base'
  'SmallGridBeamBlockSlope2x1Tip'
  'SmallGridBeamBlockHalf'
  'SmallGridBeamBlockHalfSlope'
  'SmallGridBeamBlockEnd'
  'SmallGridBeamBlockJunction'
  'SmallGridBeamBlockTJunction'

  'SmallArmorPanelLight'
  'SmallArmorSlopedSidePanelLight'
  'SmallArmorSlopedPanelLight'
  'SmallArmorHalfPanelLight'
  'SmallArmorQuarterPanelLight'
  'SmallArmor2x1SlopedPanelLight'
  'SmallArmor2x1SlopedPanelTipLight'
  'SmallArmor2x1SlopedSideBasePanelLight'
  'SmallArmor2x1SlopedSideTipPanelLight'
  'SmallArmor2x1SlopedSideBasePanelLightInv'
  'SmallArmor2x1SlopedSideTipPanelLightInv'
  'SmallArmorHalfSlopedPanelLight'
  'SmallArmor2x1HalfSlopedPanelLightRight'
  'SmallArmor2x1HalfSlopedTipPanelLightRight'
  'SmallArmor2x1HalfSlopedPanelLightLeft'
  'SmallArmor2x1HalfSlopedTipPanelLightLeft'

  'SmallArmorPanelHeavy'
  'SmallArmorSlopedSidePanelHeavy'
  'SmallArmorSlopedPanelHeavy'
  'SmallArmorHalfPanelHeavy'
  'SmallArmorQuarterPanelHeavy'
  'SmallArmor2x1SlopedPanelHeavy'
  'SmallArmor2x1SlopedPanelTipHeavy'
  'SmallArmor2x1SlopedSideBasePanelHeavy'
  'SmallArmor2x1SlopedSideTipPanelHeavy'
  'SmallArmor2x1SlopedSideBasePanelHeavyInv'
  'SmallArmor2x1SlopedSideTipPanelHeavyInv'
  'SmallArmorHalfSlopedPanelHeavy'
  'SmallArmor2x1HalfSlopedPanelHeavyRight'
  'SmallArmor2x1HalfSlopedTipPanelHeavyRight'
  'SmallArmor2x1HalfSlopedPanelHeavyLeft'
  'SmallArmor2x1HalfSlopedTipPanelHeavyLeft'




  


);
$Builder = "CubeBlock"
$Freigeschaltet = "Meilenstein_ArmorDeko"

$TextBlock = '
        <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXX  zzzzz-->
          <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXX" />
          <UnlockedByGroups>
            <GroupSubtype>zzzzz</GroupSubtype>
          </UnlockedByGroups>
        </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Freigeschaltet
Write-Host $temp

}
