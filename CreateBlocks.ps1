$BlockIds = @(

  'LargeArmorPanelLight'
  'LargeArmorSlopedPanelLight'
  'LargeArmorSlopedSidePanelLight'
  'LargeArmor2x1SlopedPanelLight'
  'LargeArmor2x1SlopedPanelTipLight'
  'LargeArmor2x1SlopedSideBasePanelLight'
  'LargeArmor2x1SlopedSideTipPanelLight'
  'LargeArmor2x1SlopedSideBasePanelLightInv'
  'LargeArmor2x1SlopedSideTipPanelLightInv'
  'LargeArmorHalfSlopedPanelLight'
  'LargeArmor2x1HalfSlopedPanelLightRight'
  'LargeArmor2x1HalfSlopedTipPanelLightRight'
  'LargeArmor2x1HalfSlopedPanelLightLeft'
  'LargeArmor2x1HalfSlopedTipPanelLightLeft'
  'LargeArmorHalfPanelLight'
  'LargeArmorQuarterPanelLight'
  'SmallArmorPanelLight'
  'SmallArmorSlopedPanelLight'
  'SmallArmorSlopedSidePanelLight'
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
  'SmallArmorHalfPanelLight'
  'SmallArmorQuarterPanelLight'
  'LargeArmorPanelHeavy'
  'LargeArmorSlopedPanelHeavy'
  'LargeArmorSlopedSidePanelHeavy'
  'LargeArmor2x1SlopedPanelHeavy'
  'LargeArmor2x1SlopedPanelTipHeavy'
  'LargeArmor2x1SlopedSideBasePanelHeavy'
  'LargeArmor2x1SlopedSideTipPanelHeavy'
  'LargeArmor2x1SlopedSideBasePanelHeavyInv'
  'LargeArmor2x1SlopedSideTipPanelHeavyInv'
  'LargeArmorHalfSlopedPanelHeavy'
  'LargeArmor2x1HalfSlopedPanelHeavyRight'
  'LargeArmor2x1HalfSlopedTipPanelHeavyRight'
  'LargeArmor2x1HalfSlopedPanelHeavyLeft'
  'LargeArmor2x1HalfSlopedTipPanelHeavyLeft'
  'LargeArmorHalfPanelHeavy'
  'LargeArmorQuarterPanelHeavy'
  'SmallArmorPanelHeavy'
  'SmallArmorSlopedPanelHeavy'
  'SmallArmorSlopedSidePanelHeavy'
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
  'SmallArmorHalfPanelHeavy'
  'SmallArmorQuarterPanelHeavy'

);
$Builder = "CubeBlock"
$Gruppe = "0"

$TextBlock = '
    <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXXXXX  Gruppe zzzzz-->
      <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXXXXX" />
      <UnlockedByGroups>
        <GroupSubtype>zzzzz</GroupSubtype>
      </UnlockedByGroups>
    </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Gruppe
Write-Host $temp

}
